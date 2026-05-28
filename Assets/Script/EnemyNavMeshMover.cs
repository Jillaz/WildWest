using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshMover : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _calculateWayDelay;
    private NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(CalculateWay());
    }

    private IEnumerator CalculateWay()
    {
        var _delay = new WaitForSeconds(_calculateWayDelay);

        while (true)
        {
            float startTime = Time.realtimeSinceStartup;

            if (_navMeshAgent != null && _target != null)
            {
                _navMeshAgent.SetDestination(_target.position);
            }

            yield return _delay;
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void Init()
    {
        StartCoroutine(CalculateWay());
    }
}
