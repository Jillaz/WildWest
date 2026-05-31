using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider))]
public class EventAxeHit : MonoBehaviour
{
    private const string AxeHit = nameof(AxeHit);

    private Animator _animator;
    private Collider _collider;

    public event Action<CharacterStats> OnEnemyHit;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider>();
        _collider.enabled = false;
    }

    public void PlayMainAttack()
    {
        _animator.Play(AxeHit);
    }

    public void StartHit()
    {
        _collider.enabled = true;
    }

    public void StopHit()
    {
        _collider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CharacterStats stats))
        {
            OnEnemyHit?.Invoke(stats);
        }
    }
}
