using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Transform _weaponPosition;
    private InputSystem_Actions _inputSystem;

    private void Awake()
    {
        _inputSystem = new InputSystem_Actions();
        _inputSystem.Player.Attack.started += OnAttack;
    }

    private void Start()
    {
        _weapon.transform.SetParent(_weaponPosition);
        _weapon.transform.position = _weaponPosition.position;
    }

    private void OnEnable()
    {
        _inputSystem.Enable();
    }

    private void OnDisable()
    {
        _inputSystem?.Disable();
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        if (_weapon != null)
        {
            _weapon.MainAttack();
        }
    }
}
