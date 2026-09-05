using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Queue Wave", menuName = "Queue Wave")]
public class WavesQueue : ScriptableObject
{
    [SerializeField] private List<EnemyWave> _enemyWaves = new();
    [SerializeField] private float _delayBeforeNextWave;

    public float DelayBeforeNextWave => _delayBeforeNextWave;

    public Queue<EnemyWave> GetQueue()
    {
        var queue = new Queue<EnemyWave>();

        foreach (var wave in _enemyWaves)
        {
            queue.Enqueue(wave);
        }

        return queue;
    }
}
