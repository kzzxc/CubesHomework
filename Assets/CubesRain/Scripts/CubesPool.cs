using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubesPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<Cube> _pool = new List<Cube>();

    protected void Initialize(Cube prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            Cube spawned = Instantiate(prefab, _container.transform);
            spawned.gameObject.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected void Initialize(Cube[] prefabs)
    {
        for (int i = 0; i < _capacity; i++)
        {
            int randomIndex = Random.Range(0, prefabs.Length);
            Cube spawned = Instantiate(prefabs[randomIndex], _container.transform);
            spawned.gameObject.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out Cube result)
    {
        result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return result != null;
    }
}
