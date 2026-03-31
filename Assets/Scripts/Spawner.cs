using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;

    private float _delay = 2f;
    private Transform _randomPoint;
    private Vector3 _enemyMoveDirection;
    private bool _canSpawn = true;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private void GetRandomPoint()
    {
        int randomIndex = Random.Range(0, _spawnPoints.Length);
        _randomPoint = _spawnPoints[randomIndex];
    }   

    private void GetRandomEnemyMoveDirection()
    {
        float angle = Random.Range(0, Mathf.PI * 2);
        _enemyMoveDirection = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
    }

    private void GetEnemy()
    {
        GetRandomPoint();
        GetRandomEnemyMoveDirection();
        Instantiate(_enemyPrefab);

        _enemyPrefab.transform.position = _randomPoint.position;
        _enemyPrefab.GetComponent<Enemy>().moveDirection = _enemyMoveDirection;
    }

    private IEnumerator Spawn()
    {
        while (_canSpawn)
        {
            GetEnemy();
            yield return new WaitForSeconds(_delay);
        }                        
    }
}