using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttacker : MonoBehaviour
{
    private InputSystem_Actions _inputSystem;

    private void Awake()
    {
        _inputSystem = new InputSystem_Actions();
        _inputSystem.Player.Attack.started += OnAttack;
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
        Debug.Log("Start attack!");
    }
}
