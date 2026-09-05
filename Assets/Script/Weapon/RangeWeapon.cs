using UnityEngine;

public class RangeWeapon : Weapon
{
    [SerializeField] private RayCaster _rayCaster;
    [SerializeField] private HitSplasher _hitSplash;
    [SerializeField] private RangeWeaponAnimator _gunAnimator;
    private RaycastHit _rayCastHit;

    public override void MainAttack()
    {
        _rayCastHit = _rayCaster.RayCast();
        _gunAnimator.PlayMainAttack();

        if (_rayCastHit.collider != null)
        {
            Instantiate(_hitSplash, _rayCastHit.point, Quaternion.identity);

            if (_rayCastHit.collider.TryGetComponent(out HitPoints stats))
            {
                stats.GetDamage(_damage);
            }
        }
    }

    public override void SecondaryAttack()
    {
        Debug.Log("Gun secondary attack");
    }
}
