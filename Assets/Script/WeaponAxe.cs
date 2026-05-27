using UnityEngine;

public class WeaponAxe : Weapon
{
    public override void MainAttack()
    {
        Debug.Log("Knife main attack");
    }

    public override void SecondaryAttack()
    {
        Debug.Log("Knife secondary attack");
    }
}
