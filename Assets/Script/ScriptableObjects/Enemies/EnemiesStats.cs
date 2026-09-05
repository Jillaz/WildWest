using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Type", menuName = "Enemies")]
public class EnemiesStats : StatsConfig
{
    [SerializeField] private float _attackDelay;
    [SerializeField] private float _attackSpeed;

    public float AttackDelay => _attackDelay;

    public float AttackSpeed => _attackSpeed;
}
