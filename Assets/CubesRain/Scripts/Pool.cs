using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Pool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T[] _ObjectTemplates;
    [SerializeField] private Text _text;
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private int _totalSpawnedObjects;

    private List<T> _pool = new();

    private void Awake() => Initialize(_ObjectTemplates);

    protected bool TryGetObject(out T result)
    {
        result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);

        if (result != null)
            _totalSpawnedObjects++;
        
        return result != null;
    }

    protected void UpdateCounterText()
    {
        int totalBombsSpawned = GetTotalSpawnedObjects();
        int activeBombs = GetActiveObjectsCount();
        _text.text = $"Total {typeof(T)}'s Spawned: {totalBombsSpawned}\nActive {typeof(T)}'s: {activeBombs}";
    }

    private int GetTotalSpawnedObjects() => _totalSpawnedObjects;

    private int GetActiveObjectsCount() => _pool.Count(p => p.gameObject.activeSelf);

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
