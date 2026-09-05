using UnityEngine;

public abstract class HitPointDisplayer : MonoBehaviour
{
    [SerializeField] protected HitPoints _characterStats;

    private void OnEnable()
    {
        _characterStats.OnHitPointsUpdated += UpdateHitPointText;
    }

    private void OnDisable()
    {
        _characterStats.OnHitPointsUpdated -= UpdateHitPointText;
    }

    public abstract void UpdateHitPointText(float value);

}
