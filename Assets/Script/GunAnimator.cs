using UnityEngine;


[RequireComponent (typeof(Animator))]
public class GunAnimator : MonoBehaviour
{
    private const string Shoot = nameof(Shoot);
    
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlaymainAttack()
    {
        _animator.Play(Shoot);
    }
}
