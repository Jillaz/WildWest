using UnityEngine;

public class MeleeWeapon : Weapon
{    
    [SerializeField] private MeleeHitDetector _hitDetector;
    [SerializeField] private MeleeWeaponAnimator _meleeWeaponAnimator;

    private void OnEnable()
    {
        //_hitDetector.OnMeleeHit += OnHit;
    }

    private void OnDisable()
    {
        //_hitDetector.OnMeleeHit -= OnHit;
    }

    public override void MainAttack()
    {
        //_meleeWeaponAnimator.PlayHit();
    }

    public override void SecondaryAttack()
    {
        Debug.Log("Secondary attack");
    }

    private void OnHit(Collider other)
    {
        if (other.TryGetComponent(out HitPoints stats))
        {
            stats.GetDamage(_damage);
        }
    }
}
