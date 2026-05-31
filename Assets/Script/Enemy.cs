using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyNavMeshMover _navMeshMover;
    [SerializeField] private CharacterStats _characterStats;

    public event Action<Enemy> OnDefeated;

    private void Start()
    {
        _characterStats.OnLostAllHitPoints += Defeated;
    }

    public void SetTarget(Transform target)
    {
        _navMeshMover.SetTarget(target);
    }    

    public void Init()
    {
        _characterStats.Init();
        _navMeshMover.Init();
    }

    private void Defeated()
    {
        _navMeshMover.SetTarget(null);
        OnDefeated?.Invoke(this);
    }
}
