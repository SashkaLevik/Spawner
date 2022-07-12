using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class SpawnEnemyes : MonoBehaviour
{
    [SerializeField] private GameObject[] _monsters;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    private int _randomPosition;
    private float _spawnRate = 2f;
    private float _elapsedTime = 0.0f;

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _spawnRate)
        {
            if (TryGetObject(out GameObject monster))
            {
                _elapsedTime = 0;

                if (_spawnPoints.Count > 0)
                {
                    _randomPosition = Random.Range(0, _spawnPoints.Count);
                    SetMonster(monster, _spawnPoints[_randomPosition].position);
                    _spawnPoints.RemoveAt(_randomPosition);
                }
            }
        }                
    }

    private void Initialize()
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(_monsters[Random.Range(0, _monsters.Length)], _container.transform);
            spawned.gameObject.SetActive(false);
            _pool.Add(spawned);
        }
    }

    private bool TryGetObject(out GameObject result)
    {
        result = _pool[Random.Range(0, _pool.Count - 1)];

        return result.gameObject.activeSelf == false ? result != null : result = null;
    }

    private void SetMonster(GameObject monster, Vector3 spawnPoint)
    {
        monster.SetActive(true);
        monster.transform.position = spawnPoint;
    }          
}
