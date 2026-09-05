using TMPro;
using UnityEngine;

public class HitPointDisplayerGame : HitPointDisplayer
{
    [SerializeField] private TextMeshPro _textHitPoints;

    public override void UpdateHitPointText(float value)
    {
        _textHitPoints.text = $"{value}";
    }
}
