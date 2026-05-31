using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshMover : MonoBehaviour
{
    [SerializeField] private float _calculateWayDelay;
    private Transform _target;
    private NavMeshAgent _navMeshAgent;

    private void Start()
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
        StopAllCoroutines();
        StartCoroutine(CalculateWay());
    }
}
