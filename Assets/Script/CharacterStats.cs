using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private float _totalHitPoints;
    private float _defaultHitPoints;
    private float _minHitPoints = 0;

    private void Start()
    {
        _defaultHitPoints = _totalHitPoints;
    }

    public void GetDamage(float damage)
    {
        if (damage < 0)
        {
            Debug.Log($"Прошел отрицательный урон {damage}");
            return;
        }

        if (_totalHitPoints <= damage)
        {
            _totalHitPoints = _minHitPoints;
        }
        else
        {
            _totalHitPoints -= damage;
        }
    }

    public void Init()
    {
        _totalHitPoints = _defaultHitPoints;
    }
}
