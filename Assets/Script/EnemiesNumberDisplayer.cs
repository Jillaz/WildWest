using TMPro;
using UnityEngine;

public class EnemiesNumberDisplayer : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    private void Start()
    {
        _enemySpawner.ActiveEnemiesChanged += DisplayTimer;
    }

    private void OnDisable()
    {
        _enemySpawner.ActiveEnemiesChanged -= DisplayTimer;
    }

    private void DisplayTimer(int timer)
    {
        _textMeshPro.text = timer.ToString();
        //Debug.Log($"Следующая волна через: {timer}");
    }
}
