using System;
using UnityEngine;

[Serializable]
public class EnemySquad
{
    [SerializeField] private EnemiesStats _enemieConfig;
    [SerializeField] private int _count;
    [SerializeField] private float _spawnDelay;

    public EnemiesStats EnemyConfig => _enemieConfig;
    public int Count => _count;
    public float SpawnDelay => _spawnDelay;
}
