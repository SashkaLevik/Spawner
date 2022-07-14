using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class SpawnEnemyes : ObjectPool
{
    [SerializeField] public Monster[] _monsters;
    [SerializeField] private List<Transform> _spawnPoints;
    
    private int _randomPosition;

    private void Start()
    {
        Initialize(_monsters);
        StartCoroutine(Spawn());
    }     

    private IEnumerator Spawn()
    {
        var waitTwoSeconds = new WaitForSeconds(2F);

        while (_spawnPoints.Count > 0)
        {
            if (TryGetObject(out Monster monster))
            {
                _randomPosition = Random.Range(0, _spawnPoints.Count);
                SetMonster(monster, _spawnPoints[_randomPosition].position);
                _spawnPoints.RemoveAt(_randomPosition);
                yield return waitTwoSeconds;
            }
        }
        
    }

    private void SetMonster(Monster monster, Vector3 spawnPoint)
    {
        monster.gameObject.SetActive(true);
        monster.transform.position = spawnPoint;
    }          
}
