using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    private static string Attack = nameof(Attack);
    private static string Run = nameof(Run);
    private static string AttackSpeed = nameof(AttackSpeed);
    private static string isCanAttack = nameof(isCanAttack);

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetAttackSpeed(float speed)
    {
        _animator.SetFloat(AttackSpeed, speed);        
    }

    public void PlayAttack()
    {
        _animator.Play(Attack);        
    }

    public void PlayRun()
    {
        _animator.Play(Run);
    }
}
