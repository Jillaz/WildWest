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
            Debug.Log($"Gun hit {_rayCastHit.point}");
            Instantiate(_hitSplash, _rayCastHit.point, Quaternion.identity);
        }
        else
        {
            Debug.Log($"Gun hit MISSED");
        }
    }

    public override void SecondaryAttack()
    {
        throw new System.NotImplementedException();
    }
}
