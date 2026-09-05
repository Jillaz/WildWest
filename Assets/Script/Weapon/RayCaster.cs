using UnityEngine;
using UnityEngine.UI;

public class RayCaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _rayCastDistance = 1000f;
    [SerializeField] private Image _image;

    private Vector2 _screenCenterPoint;
    private float _screenSeparator = 2f;

    private void Start()
    {
        _screenCenterPoint = new Vector2(Screen.width / _screenSeparator, Screen.height / _screenSeparator);
        _image.transform.position = _screenCenterPoint;
    }

    public RaycastHit RayCast()
    {
        Ray ray = _camera.ScreenPointToRay(_screenCenterPoint);

        if (Physics.Raycast(ray, out RaycastHit hit, _rayCastDistance))
        {
            return hit;
        }

        return default;
    }
}
