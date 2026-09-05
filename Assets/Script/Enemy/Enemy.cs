using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyNavMeshMover _navMeshMover;
    [SerializeField] private HitPoints _characterStats;
    [SerializeField] private EnemyAttacker _enemyAttacker;

    public event Action<Enemy> OnDefeated;

    private void Start()
    {
        _characterStats.OnLostAllHitPoints += Defeated;
    }

    public void SetTarget(Transform target)
    {
        _navMeshMover.SetTarget(target);
    }

    public void Init(EnemiesStats config)
    {
        _characterStats.Init(config);
        _navMeshMover.Init(config);
        _enemyAttacker.Init(config);
        transform.localScale = Vector3.one * config.Size;
    }

    private void Defeated()
    {
        _navMeshMover.SetTarget(null);
        OnDefeated?.Invoke(this);
    }
}
