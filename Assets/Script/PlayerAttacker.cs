using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    private InputSystem_Actions _inputSystem;

    private void Awake()
    {
        _inputSystem = new InputSystem_Actions();
        _inputSystem.Player.Attack.started += OnAttack;
        _inputSystem.Player.SecondaryAttack.started += OnSecondaryAttack;
    }
    
    private void OnEnable()
    {
        _inputSystem.Enable();
    }

    private void OnDisable()
    {
        _inputSystem?.Disable();
    }

    public void SetWeapon(Weapon weapon)
    {
        _weapon = weapon;
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        if (_weapon != null)
        {
            _weapon.MainAttack();
        }
    }

    private void OnSecondaryAttack(InputAction.CallbackContext context)
    {
        if (_weapon != null)
        {
            _weapon.SecondaryAttack();
        }
    }
}
