
//using UnityEngine;

//[CreateAssetMenu(fileName = "Enemy Follow State", menuName = "EnemyFollowState")]
//public class EnemyStateFollowSO : EnemyStateSO
//{
//    public override void OnEnter()
//    {
//        Debug.Log("Follow Enter");
//        Debug.Log($"Follow Enter Target {_core.Target}");
//        _mover.SetTarget(_core.Target);
//        _mover.Init(_stats);
//        _mover.TargetReached += EnterInAttackRange;
//        _mover.StartMoving();
//        _animator.PlayRun();
//    }

//    public override void OnUpdate()
//    {
//        if (_mover.IsTargetExist())
//        {
//            return;
//        }
//        else
//        {
//            _mover.StopMoving();
//        }
//    }

//    public override void OnExit()
//    {
//        _mover.StopMoving();
//    }

//    public override bool IsCanChangeState()
//    {
//        return true;
//    }

//    private void EnterInAttackRange()
//    {
//        _mover.TargetReached -= EnterInAttackRange;
//        _core.ChangeState(_core.AttackState);
//    }
//}
