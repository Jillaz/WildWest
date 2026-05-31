using System;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private float _defaultHitPoints;
    private float _currentHitPoints;
    private float _minHitPoints = 0;

    public event Action<float> OnHitPointsUpdated;
    public event Action OnLostAllHitPoints;

    private void Start()
    {
        Init();
    }

    public void GetDamage(float damage)
    {
        if (damage < 0)
        {
            Debug.Log($"Прошел отрицательный урон {damage}");
            return;
        }

        if (_currentHitPoints <= damage)
        {
            _currentHitPoints = _minHitPoints;
            OnLostAllHitPoints?.Invoke();
        }
        else
        {
            _currentHitPoints -= damage;
        }

        OnHitPointsUpdated?.Invoke(_currentHitPoints);
    }

    public void Init()
    {
        _currentHitPoints = _defaultHitPoints;
        OnHitPointsUpdated?.Invoke(_currentHitPoints);
    }
}
