using UnityEngine;

public class WeaponGun : Weapon
{
    [SerializeField] private RayCaster _rayCaster;
    [SerializeField] private HitSplasher _hitSplash;
    [SerializeField] private GunAnimator _gunAnimator;
    private RaycastHit _rayCastHit;

    public override void MainAttack()
    {
        _rayCastHit = _rayCaster.RayCast();
        _gunAnimator.PlaymainAttack();

        Debug.Log(_rayCastHit.ToString());

        if (_rayCastHit.point != Vector3.zero)
        {
            Instantiate(_hitSplash, _rayCastHit.point, Quaternion.identity);

            if (_rayCastHit.collider.TryGetComponent(out CharacterStats stats))
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
