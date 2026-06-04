using UnityEngine;

public class MeleeHitZoneEnabler : MonoBehaviour
{
    [SerializeField] private Collider _hitZoneCollider;
    
    public void StartHit()
    {
        _hitZoneCollider.enabled = true;
    }

    public void StopHit()
    {
        _hitZoneCollider.enabled = false;
    }
}
