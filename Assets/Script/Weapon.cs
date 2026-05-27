using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private float _damage;

    public abstract void MainAttack();

    public abstract void SecondaryAttack();
}
