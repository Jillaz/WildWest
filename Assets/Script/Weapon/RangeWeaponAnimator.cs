using UnityEngine;

[RequireComponent(typeof(Animator))]

public class RangeWeaponAnimator : MonoBehaviour
{
    private const string Shoot = nameof(Shoot);

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayMainAttack()
    {
        _animator.Play(Shoot);
    }
}
