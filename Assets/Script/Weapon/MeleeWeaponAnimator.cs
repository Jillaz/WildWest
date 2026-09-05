using UnityEngine;

[RequireComponent(typeof(Animator))]

public class MeleeWeaponAnimator : MonoBehaviour
{
    private const string Hit = nameof(Hit);

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayHit()
    {
        _animator.Play(Hit);
    }
}
