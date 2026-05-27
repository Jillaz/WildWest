using System;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private float _totalHitPoints;
    private float _defaultHitPoints;
    private float _minHitPoints = 0;

    public event Action<float> HitPointsUpdated;

    private void Start()
    {
        _defaultHitPoints = _totalHitPoints;
        HitPointsUpdated?.Invoke(_totalHitPoints);
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

        HitPointsUpdated?.Invoke(_totalHitPoints);
    }

    public void Init()
    {
        _totalHitPoints = _defaultHitPoints;
        HitPointsUpdated?.Invoke(_totalHitPoints);
    }
}
