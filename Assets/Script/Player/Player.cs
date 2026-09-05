using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private StatsConfig _statsConfig;
    [SerializeField] private HitPoints _hitPoints;
    [SerializeField] private PlayerMover _mover;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _hitPoints.Init(_statsConfig);
        _mover.Init(_statsConfig);
    }

}
