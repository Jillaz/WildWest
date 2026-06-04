using System;
using UnityEngine;

public class MeleeHitDetector : MonoBehaviour
{
    private Collider _collider;

    public event Action<Collider> OnMeleeHit;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _collider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        OnMeleeHit?.Invoke(other);
    }
}
