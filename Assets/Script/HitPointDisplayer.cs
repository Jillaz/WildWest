using TMPro;
using UnityEngine;

public class HitPointDisplayer : MonoBehaviour
{
    [SerializeField] private CharacterStats _characterStats;
    [SerializeField] private TextMeshPro _textHitPoints;

    private void Start()
    {
        _characterStats.HitPointsUpdated += UpdateHitPointText;
    }

    private void UpdateHitPointText(float value)
    {
        _textHitPoints.text = $"{value}";
    }
}
