using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyNavMeshMover _navMeshMover;
    [SerializeField] private CharacterStats _characterStats;
    private float _minHitPointValue = 0;

    public event Action<Enemy> Defeated; 

    private void Start()
    {
        _characterStats.HitPointsUpdated += Shoted;
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

    private void Shoted(float value)
    {
        if (value <= _minHitPointValue)
        {
            Defeated?.Invoke(this);
        }
    }
}
