using NUnit.Framework.Constraints;
using System;
using UnityEngine;

public class WeaponsPool : MonoBehaviour
{
    [SerializeField] private Weapon _axePrefab;
    [SerializeField] private Weapon _hammerPrefab;
    [SerializeField] private Weapon _revolverPrefab;
    private GenericPool<Weapon> _axePool;
    private GenericPool<Weapon> _hammerPool;
    private GenericPool<Weapon> _revolverPool;

    private void Start()
    {
        _axePool = new GenericPool<Weapon>(_axePrefab);
        _hammerPool = new GenericPool<Weapon>(_hammerPrefab);
        _revolverPool = new GenericPool<Weapon>(_revolverPrefab);
    }

    public Weapon GetWeapon(WeaponsModelType weaponType)
    {
        Weapon newWeapon = null;

        switch (weaponType)
        {
            case WeaponsModelType.Axe:
                newWeapon = _axePool.Get();
                break;
            case WeaponsModelType.Hammer:
                newWeapon = _hammerPool.Get();
                break;
            case WeaponsModelType.Revolver:
                newWeapon = _revolverPool.Get();
                break;
            default:
                Debug.Log("Нет такого типа оружия");
                break;
        }

        return newWeapon;
    }
}
