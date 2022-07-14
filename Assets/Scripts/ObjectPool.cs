using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<Monster> _pool = new List<Monster>();    

    protected void Initialize(Monster[] monsters)
    {
        for (int i = 0; i < _capacity; i++)
        {
            Monster spawned = Instantiate(monsters[Random.Range(0, monsters.Length)], _container.transform);
            spawned.gameObject.SetActive(false);
            _pool.Add(spawned);
        }
    }    

    protected bool TryGetObject(out Monster result)
    {
        result = _pool[Random.Range(0, _pool.Count)];

        return result.gameObject.activeSelf == false;
    }
}
