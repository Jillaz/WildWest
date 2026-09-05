using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSelector : MonoBehaviour
{
    [SerializeField] private PlayerAttacker _playerAttacker;
    [SerializeField] private Weapon _weaponGun;
    [SerializeField] private Weapon _weaponAxe;
    private InputSystem_Actions _inputSystem;
    private Weapon _weaponInUse;

    private void Awake()
    {
        _inputSystem = new InputSystem_Actions();
        _inputSystem.Player.SwitchWeapon.started += SwitchWeapon;
    }

    private void Start()
    {
        _weaponAxe.gameObject.SetActive(false);

        _weaponInUse = _weaponGun;
        _playerAttacker.SetWeapon(_weaponInUse);
    }

    private void OnEnable()
    {
        _inputSystem.Enable();
    }

    private void OnDisable()
    {
        _inputSystem?.Disable();
    }

    private void SwitchWeapon(InputAction.CallbackContext context)
    {
        if (_weaponInUse == _weaponGun)
        {
            _weaponInUse = _weaponAxe;        
            _weaponGun.gameObject.SetActive(false);
            _weaponAxe.gameObject.SetActive(true);
        }
        else if (_weaponInUse == _weaponAxe)
        {
            _weaponInUse = _weaponGun;
            _weaponGun.gameObject.SetActive(true);
            _weaponAxe.gameObject.SetActive(false);
        }

        _playerAttacker.SetWeapon(_weaponInUse);
    }
}
