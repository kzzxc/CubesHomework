using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Pool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T[] _ObjectTemplates;
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<T> _pool = new();

    private void Awake() => Initialize(_ObjectTemplates);

    protected bool TryGetObject(out T result)
    {
        result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return result != null;
    }

    private void Initialize(T[] prefabs)
    {
        for (int i = 0; i < _capacity; i++)
        {
            int randomIndex = Random.Range(0, prefabs.Length);
            T spawned = Instantiate(prefabs[randomIndex], _container.transform);
            spawned.gameObject.SetActive(false);

            _pool.Add(spawned);
        }
    }

}
