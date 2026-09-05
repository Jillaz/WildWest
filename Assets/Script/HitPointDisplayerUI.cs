using TMPro;
using UnityEngine;

public class HitPointDisplayerUI : HitPointDisplayer
{
    [SerializeField] private TextMeshProUGUI _textHitPoints;

    public override void UpdateHitPointText(float value)
    {
        _textHitPoints.text = $"{value}";
    }
}
