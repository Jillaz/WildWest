using UnityEngine;

public class MeleeWeapon : Weapon
{
    private static string Hit = nameof(Hit);
    
    [SerializeField] private MeleeHitDetector _hitDetector;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _hitDetector.OnMeleeHit += OnHit;
    }

    private void OnDisable()
    {
        _hitDetector.OnMeleeHit -= OnHit;
    }

    public override void MainAttack()
    {
        _animator.Play(Hit);
    }

    public override void SecondaryAttack()
    {
        Debug.Log("Secondary attack");
    }

    private void OnHit(Collider other)
    {
        if (other.TryGetComponent(out CharacterStats stats))
        {
            stats.GetDamage(_damage);
        }
    }
}
