using System;
using System.Collections;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] EnemyAnimator _animator;
    private float _attackDelay;
    private bool _isCanAttack;
    private bool _isAttacking;

    public event Action<bool> AttackFinished;
    
    public void Init(EnemiesStats stats)
    {
        _animator.SetAttackSpeed(stats.AttackSpeed);
        _attackDelay = stats.AttackDelay;
    }

    public void SwitchAttackOn(bool isCanAttack)
    {
        _isCanAttack = isCanAttack;
    }

    private void Update()
    {
        if (_isCanAttack == false)
        {
            return;
        }

        if (_isAttacking == false)
        {
            _isAttacking = true;
            AttackFinished?.Invoke(false);

            StartCoroutine(PerformAttack());
        }
    }

    private IEnumerator PerformAttack()
    {
        var delay = new WaitForSeconds(_attackDelay);

        while (_isCanAttack)        
        {
            _animator.PlayAttack();

            yield return delay;
        }

        _isAttacking = false;
        AttackFinished?.Invoke(true);
    }
}

