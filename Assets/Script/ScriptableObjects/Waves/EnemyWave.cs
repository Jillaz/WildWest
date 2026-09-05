using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Wave", menuName = "EnemyWave")]
public class EnemyWave : ScriptableObject
{
    [SerializeField] private WaveType _waveType;
    [SerializeField] private string _name;
    [SerializeField] private List<EnemySquad> _wave = new();

    public WaveType WaveType => _waveType;

    public List<EnemySquad> Wave()
    {
        List<EnemySquad> newWave = new();

        foreach (EnemySquad wave in _wave)
        {
            newWave.Add(wave);
        }

        return newWave;
    }
}
