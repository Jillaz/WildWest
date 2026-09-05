using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshMover : MonoBehaviour
{
    [SerializeField] private float _calculateWayDelay;
    private Transform _target;
    private NavMeshAgent _navMeshAgent;
    private float _attackRange;

    public event Action TargetReached;
    public event Action TargetLost;
    public event Action<bool> TargetInAttackRange;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private IEnumerator CalculateWay()
    {
        var _delay = new WaitForSeconds(_calculateWayDelay);

        while (_target != null)
        {
            if (_navMeshAgent != null)
            {
                _navMeshAgent.SetDestination(_target.position);

                if (_navMeshAgent.remainingDistance <= _attackRange)
                {
                    TargetReached?.Invoke();
                    TargetInAttackRange?.Invoke(true);

                    RotateToTarget();
                }
                else
                {
                    TargetLost?.Invoke();
                    TargetInAttackRange?.Invoke(false);
                }
            }

            yield return _delay;
        }
    }

    private void RotateToTarget()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        direction.y = 0;

        transform.rotation = Quaternion.LookRotation(direction);
    }

    public void StopMoving()
    {
        _navMeshAgent.isStopped = true;
    }

    public void StartMoving()
    {
        _navMeshAgent.isStopped = false;
    }

    public bool IsTargetExist()
    {
        return _target != null;
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void Init(EnemiesStats config)
    {
        _navMeshAgent.speed = config.MoveSpeed;
        _attackRange = config.AttackRange;
        StopAllCoroutines();

        StartCoroutine(CalculateWay());
    }
}
