using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected string _name;
    [SerializeField] protected float _damage;

    public abstract void MainAttack();

    public abstract void SecondaryAttack();
}
