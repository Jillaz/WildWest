using UnityEngine;

public class WeaponAxe : Weapon
{
    [SerializeField] private Animator _animator;
    [SerializeField] private EventAxeHit _axeHit;

    private void OnEnable()
    {
        _axeHit.OnEnemyHit += EnemyHit;        
    }

    private void OnDisable()
    {
        _axeHit.OnEnemyHit -= EnemyHit;
    }

    public override void MainAttack()
    {
        _axeHit.PlayMainAttack();
    }

    public override void SecondaryAttack()
    {
        Debug.Log("Knife secondary attack");
    }

    private void EnemyHit(CharacterStats stats)
    {
        stats.GetDamage(_damage);
    }
}
