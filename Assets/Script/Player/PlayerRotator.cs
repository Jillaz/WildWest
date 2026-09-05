using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotator : MonoBehaviour
{
    [SerializeField] private Camera _lookCamera;

    private InputSystem_Actions _inputSystem;
    private Vector2 _lookInput;
    private Vector2 _look;

    private void Awake()
    {
        _inputSystem = new InputSystem_Actions();
        _inputSystem.Player.Look.performed += OnMouseLook;
        _lookCamera.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    private void OnMouseLook(InputAction.CallbackContext context)
    {
        _lookInput = context.ReadValue<Vector2>();
        _look.y += _lookInput.y;
        _look.x += _lookInput.x;
    }

    private void OnEnable()
    {
        _inputSystem.Enable();
    }

    private void OnDisable()
    {
        _inputSystem.Disable();
    }

    private void Update()
    {
        _look.y = Mathf.Clamp(_look.y, -90f, 90f);

        transform.localRotation = Quaternion.Euler(0, _look.x, 0);
        _lookCamera.transform.localRotation = Quaternion.Euler(-_look.y, 0, 0);
    }
}
