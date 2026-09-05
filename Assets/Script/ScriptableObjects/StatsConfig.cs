using UnityEngine;

[CreateAssetMenu(fileName = "Stats config", menuName = "Stats config")]
public class StatsConfig : ScriptableObject
{
    [SerializeField] protected float _hitPoints;
    [SerializeField] protected float _moveSpeed;
    [SerializeField] protected float _size;
    [SerializeField] protected float _attackRange;
    [SerializeField] protected GameObject _modelPrefab;
    [SerializeField] protected WeaponsModelType _weaponType;

    public float HitPoints => _hitPoints;
    public float MoveSpeed => _moveSpeed;
    public float Size => _size;
    public float AttackRange => _attackRange;
    public GameObject ModelPrefab => _modelPrefab;
    public WeaponsModelType WeaponType => _weaponType;
}
