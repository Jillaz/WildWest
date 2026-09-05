using System;
using UnityEngine;

public class HitPoints : MonoBehaviour
{
    private float _currentHitPoints;
    private float _minHitPoints = 0;

    public event Action<float> OnHitPointsUpdated;
    public event Action OnLostAllHitPoints;
    
    public void Init(StatsConfig config)
    {
        _currentHitPoints = config.HitPoints;
        OnHitPointsUpdated?.Invoke(_currentHitPoints);
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
}
