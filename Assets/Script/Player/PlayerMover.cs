using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    private InputSystem_Actions _inputSystem;
    private Vector3 _moveDirection;
    private float _speed;

    private void Awake()
    {
        _inputSystem = new InputSystem_Actions();
        _inputSystem.Player.Move3d.performed += OnMove;
        _inputSystem.Player.Move3d.canceled += OnStopMoving;
    }

    public void Init(StatsConfig stats)
    {
        _speed = stats.MoveSpeed;
    }

    private void OnEnable()
    {
        _inputSystem.Enable();
    }

    private void OnDisable()
    {
        _inputSystem?.Disable();
    }

    private void Update()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime);
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _moveDirection=context.ReadValue<Vector3>();
    }

    private void OnStopMoving(InputAction.CallbackContext context)
    {
        _moveDirection = Vector3.zero;        
    }
}

