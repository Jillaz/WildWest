using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _Prefab;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private Transform _player;
    private GenericPool<Enemy> _pool;
    private Vector3 _spawnPosition = Vector3.one;

    private void Awake()
    {
        _pool = new GenericPool<Enemy>(_Prefab);
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var delay = new WaitForSeconds(_spawnDelay);

        while (true)
        {
            Enemy enemy = _pool.Get();
            enemy.transform.position = _spawnPosition;
            enemy.SetTarget(_player);
            enemy.Init();
            enemy.Defeated += Release;

            yield return delay;
        }
    }

    private void Release(Enemy enemy)
    {
        enemy.Defeated -= Release;
        _pool.Release(enemy);
    }
}
