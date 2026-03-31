using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;

    private float _delay = 2f;
    private bool _canSpawn = true;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private Vector3 GetRandomPoint()
    {
        int randomIndex = Random.Range(0, _spawnPoints.Length);
        return _spawnPoints[randomIndex].position;
    }   

    private Vector3 GetRandomEnemyMoveDirection()
    {
        float angle = Random.Range(0, Mathf.PI * 2);
        Vector3 direction = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
        return direction;
    }

    private void GetEnemy()
    {
        Vector3 spawnPoint = GetRandomPoint();
        Vector3 direction = GetRandomEnemyMoveDirection();

        Enemy enemyInstance = Instantiate(_enemyPrefab,spawnPoint,Quaternion.identity);
        enemyInstance.ChangeMoveDirection(direction);
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