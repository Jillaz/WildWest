using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _attackDelay;
    [SerializeField] private float _minAttackDistance;

    private void Update()
    {
        if (_navMeshAgent.remainingDistance <= _minAttackDistance)
        {
            StartCoroutine(Attack());
        }
        else
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator Attack()
    {
        var attackDelay = new WaitForSeconds(_attackDelay);

        while (enabled)
        {
            _weapon.MainAttack();

            yield return attackDelay;
        }
    }
}
