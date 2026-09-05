using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyCore _prefab;
    [SerializeField] private WeaponsPool _weaponPool;
    [SerializeField] private Transform _player;
    [SerializeField] private SpawnPointGenerator _spawnPointGenerator;
    [SerializeField] private int _enemySpawnCount;
    private GenericPool<EnemyCore> _pool;
    private HashSet<EnemyCore> _activeEnemies;

    public event Action<int> ActiveEnemiesChanged;
    public event Action WaveSpawned;

    private void Awake()
    {
        _pool = new GenericPool<EnemyCore>(_prefab);
    }

    private void Start()
    {
        _activeEnemies = new HashSet<EnemyCore>();
    }    

    public void StartSpawn(List<EnemySquad> enemySquad)
    {
        StartCoroutine(Spawn(enemySquad));
    }

    private IEnumerator Spawn(List<EnemySquad> enemySquad)
    {
        foreach (var enemySet in enemySquad)
        {            
            var delay = new WaitForSeconds(enemySet.SpawnDelay);
            _enemySpawnCount = enemySet.Count;

            while (_enemySpawnCount > 0)
            {
                EnemyCore enemy = _pool.Get();
                enemy.transform.position = _spawnPointGenerator.GetSpawnPosition(_player.position);
                enemy.SetTarget(_player);
                enemy.Init(enemySet.EnemyConfig);
                enemy.GetWeaponFromPool(_weaponPool);
                enemy.OnDefeated += Release;

                _activeEnemies.Add(enemy);
                ActiveEnemiesChanged?.Invoke(_activeEnemies.Count);

                _enemySpawnCount--;

                yield return delay;
            }
        }

        WaveSpawned?.Invoke();
    }

    private void Release(EnemyCore enemy)
    {
        enemy.OnDefeated -= Release;
        _pool.Release(enemy);
        
        _activeEnemies.Remove(enemy);
        ActiveEnemiesChanged?.Invoke(_activeEnemies.Count);
    }    
}
