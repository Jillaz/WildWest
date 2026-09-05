using UnityEngine;
using UnityEngine.AI;

public class SpawnPointGenerator : MonoBehaviour
{
    [SerializeField] private float _minSpawnDistanceFromPlayer;
    [SerializeField] private float _maxSpawnDistanceFromPlayer;
    [SerializeField] private float _navMeshCheckRadius;
    private Vector3 _spawnPosition;
    private bool _isSpawning;
    private int _spawnTry;

    public Vector3 GetSpawnPosition(Vector3 playerPosition)
    {
        _isSpawning = false;
        _spawnTry = 100;

        while (_isSpawning == false && _spawnTry > 0)
        {
            Vector2 randomCircleDirection = Random.insideUnitCircle.normalized;
            Vector3 randomDirection = new Vector3(randomCircleDirection.x, 0, randomCircleDirection.y);
            float randomDistance = Random.Range(_minSpawnDistanceFromPlayer, _maxSpawnDistanceFromPlayer);
            _spawnPosition = playerPosition + randomDirection * randomDistance;

            if (NavMesh.SamplePosition(_spawnPosition, out NavMeshHit hit, _navMeshCheckRadius, NavMesh.AllAreas))
            {
                _isSpawning = true;
            }

            _spawnTry--;
        }

        if (_spawnTry == 0)
        {
            Debug.Log(_spawnPosition);
        }

        return _spawnPosition;
    }
}
