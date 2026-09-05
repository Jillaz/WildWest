using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField] private WavesQueue _wavesQueue;
    [SerializeField] private EnemySpawner _spawner;
    private Queue<EnemyWave> _enemyWave;
    private float _delayBeforeNextWave;
    private List<EnemySquad> _currentWave;

    public event Action<string> CountDownTimeChanged;
    public event Action CountDownTimeStopped;
    public event Action<WaveType> WaveTypeChanged;

    private void Start()
    {
        _spawner.WaveSpawned += PullWave;
        _enemyWave = _wavesQueue.GetQueue();
        PullWave();
    }

    private void OnDisable()
    {
        _spawner.WaveSpawned -= PullWave;
    }

    private void PullWave()
    {
        _delayBeforeNextWave = _wavesQueue.DelayBeforeNextWave;

        if (_enemyWave.Count == 0)
        {
            Debug.Log("WaveQueue is Empty!");
            return;
        }

        EnemyWave enemyWave = _enemyWave.Dequeue();
        _currentWave = enemyWave.Wave();

        WaveTypeChanged?.Invoke(enemyWave.WaveType);
        StartCoroutine(CountDownTimer());
    }

    private IEnumerator CountDownTimer()
    {
        float second = 1.0f;
        float stopTimer = 0f;
        var delay = new WaitForSeconds(second);

        while (_delayBeforeNextWave > stopTimer)
        {
            CountDownTimeChanged?.Invoke(_delayBeforeNextWave.ToString());

            _delayBeforeNextWave--;

            yield return delay;
        }

        CountDownTimeStopped?.Invoke();
        _spawner.StartSpawn(_currentWave);
    }
}
