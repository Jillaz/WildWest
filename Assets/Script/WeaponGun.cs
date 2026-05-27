using UnityEngine;

public class WeaponGun : Weapon
{
    [SerializeField] private RayCaster _rayCaster;
    [SerializeField] private HitSplasher _hitSplash;
    private RaycastHit _rayCastHit;

    public override void MainAttack()
    {
        _rayCastHit = _rayCaster.RayCast();

        if (_rayCastHit.point != Vector3.zero)
        {
            Instantiate(_hitSplash, _rayCastHit.point, Quaternion.identity);
        }
    }

    public override void SecondaryAttack()
    {
        Debug.Log("Gun secondary attack");
    }
}
