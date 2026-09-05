//using System.Collections;
//using UnityEngine;

//[CreateAssetMenu(fileName = "Enemy Attack State", menuName = "EnemyAttackState")]
//public class EnemyStateAttackSO : EnemyStateSO
//{
//    private float _attackDelay;
//    private bool _isAttacking = false;
//    private bool _isInAttackRange = false;
//    private float _nextAttackTime;

//    public override void OnEnter()
//    {
//        _attackDelay = _stats.AttackDelay;
//        _animator.SetAttackSpeed(_stats.AttackSpeed);
//        _isInAttackRange = true;
//        _nextAttackTime = 0f;
//        _mover.TargetLost += TargetLeftAttackRange;
//    }

//    public override void OnUpdate()
//    {
//        if (_isInAttackRange && Time.time > _nextAttackTime)
//        {
//            PerformAttack();
//        }

//        if (_isAttacking && Time.time > _nextAttackTime)
//        {
//            _isAttacking = false;

//            if (_isInAttackRange == false)
//            {
//                _core.ChangeState(_core.FollowState);
//            }
//        }
//    }

//    public override void OnExit()
//    {
//    }

//    public override bool IsCanChangeState()
//    {
//        return true;
//    }

//    private void TargetLeftAttackRange()
//    {
//        _mover.TargetLost -= TargetLeftAttackRange;
//        _isInAttackRange = false;
//    }

//    private void PerformAttack()
//    {
//        if (_isAttacking)
//        {
//            return;
//        }

//        _isAttacking = true;
//        _nextAttackTime = Time.time + _attackDelay;

//        _animator.PlayAttack();
//    }
//}
