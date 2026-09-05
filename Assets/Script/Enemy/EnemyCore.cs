using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(EnemyNavMeshMover))]
[RequireComponent(typeof(EnemyAttacker))]
[RequireComponent(typeof(HitPoints))]
public class EnemyCore : MonoBehaviour
{
    [SerializeField] private EnemyAnimator _animator;
    private Transform _target;

    private EnemyNavMeshMover _mover;
    private EnemyAttacker _attacker;
    private HitPoints _hitPoints;
    private EnemyState _enemyCurrentState = EnemyState.None;
    private EnemyState _enemyNewState = EnemyState.None;
    private EnemiesStats _stats;
    private bool _isCanChangeState = true;

    public event Action<EnemyCore> OnDefeated;

    private void Awake()
    {
        _mover = GetComponent<EnemyNavMeshMover>();
        _attacker = GetComponent<EnemyAttacker>();
        _hitPoints = GetComponent<HitPoints>();

        _hitPoints.OnLostAllHitPoints += Defeated;
        _mover.TargetReached += TargetInAttackRange;
        _mover.TargetLost += TargetOutAttackRange;
    }

    private void Start()
    {
        SetNewState(EnemyState.FollowPlayer);
    }

    private void Update()
    {
        if (_isCanChangeState == false)
        {
            return;
        }

        if (_enemyNewState == _enemyCurrentState)
        {
            return;
        }

        Debug.Log("ChangeState");

        ChangeState();

        _enemyCurrentState = _enemyNewState;
    }

    private void SetNewState(EnemyState newState)
    {
        _enemyNewState = newState;
    }

    private void ChangeState()
    {
        switch (_enemyNewState)
        {
            case EnemyState.FollowPlayer:
                SetFollowState();
                break;
            case EnemyState.Attack:
                SetAttackState();
                break;
            default:
                break;
        }
    }

    private void SetAttackState()
    {
        _isCanChangeState = false;
        _attacker.AttackFinished += IsCanChangeState;
        _attacker.Init(_stats);        
        _mover.StopMoving();
    }

    private void SetFollowState()
    {
        _attacker.AttackFinished -= IsCanChangeState;
        _isCanChangeState = true;
        _mover.SetTarget(_target);
        _mover.Init(_stats);
        _mover.StartMoving();
        _animator.PlayRun();

    }

    private void TargetInAttackRange()
    {
        Debug.Log("TargetInAttackRange");
        _attacker.SwitchAttackOn(true);
        SetNewState(EnemyState.Attack);
    }

    private void TargetOutAttackRange()
    {
        Debug.Log("TargetOutAttackRange");
        _attacker.SwitchAttackOn(false);
        SetNewState(EnemyState.FollowPlayer);
    }
    
    private void IsCanChangeState(bool isCanChangeState)
    {
        _isCanChangeState = isCanChangeState;
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void Init(EnemiesStats config)
    {
        _stats = config;
        _hitPoints.Init(config);
    }

    private void Defeated()
    {
        _mover.SetTarget(null);
        OnDefeated?.Invoke(this);
        _hitPoints.OnLostAllHitPoints -= Defeated;
    }
}
