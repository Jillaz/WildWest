using UnityEngine;

public class HitSplasher : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hitSplash;

    private void Start()
    {
        Destroy(gameObject, 1f);
    }

}
