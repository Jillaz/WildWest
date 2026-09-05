using TMPro;
using UnityEngine;

public class TimerDisplayer : MonoBehaviour
{
    [SerializeField] private WaveController _waveController;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    private WaveType _waveType;
    private string _timerEmpty = string.Empty;
    private string _defaultEnemyText = "Enemy spawn at: ";
    private string _bossText = "Boss spawn at: ";
    private string _noWaveType = "Wave without type!";

    private void Start()
    {
        _waveController.CountDownTimeChanged += DisplayTimer;
        _waveController.CountDownTimeStopped += StopTimer;
        _waveController.WaveTypeChanged += ChangeWaveType;
    }

    private void OnDisable()
    {
        _waveController.CountDownTimeChanged -= DisplayTimer;
        _waveController.CountDownTimeStopped -= StopTimer;
        _waveController.WaveTypeChanged -= ChangeWaveType;
    }

    private void DisplayTimer(string timer)
    {

        switch (_waveType)
        {
            case WaveType.Default:
                _textMeshPro.text = _defaultEnemyText + timer;
                break;
            case WaveType.Boss:
                _textMeshPro.text = _bossText + timer;
                break;
            default:
                _textMeshPro.text = _noWaveType;
                break;
        }
    }

    private void StopTimer()
    {
        _textMeshPro.text = _timerEmpty;
    }

    private void ChangeWaveType(WaveType waveType)
    {
        _waveType = waveType;
    }
}
