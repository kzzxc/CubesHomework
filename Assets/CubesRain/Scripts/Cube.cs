using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    [SerializeField] private CubeCollisionHandler _collisionHandler;
    [SerializeField] private Renderer _renderer;
    
    private Coroutine _currentCoroutine;
    private BombSpawner _bombSpawner;

    private void Start() => _bombSpawner = FindObjectOfType<BombSpawner>();

    private void OnEnable()
    {
        _collisionHandler.Fall += OnFall;
        _renderer.material.color = Color.white;
    }

    private void OnDisable()
    {
        _collisionHandler.Fall -= OnFall;

        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
            _currentCoroutine = null;
        }
    }

    private void OnFall()
    {
        if (_currentCoroutine == null)
            _currentCoroutine = StartCoroutine(UpdateCubeProperties());
    }

    private IEnumerator UpdateCubeProperties()
    {
        _renderer.material.color = Random.ColorHSV();
        var lifetime = GetLifetime();

        WaitForSeconds wait = new WaitForSeconds(lifetime);

        yield return wait;

        gameObject.SetActive(false);
        
        _bombSpawner.SpawnBomb(transform.position, GetLifetime());
    }

    private int GetLifetime()
    {
        int minLifetime = 2;
        int maxLifetime = 5;

        return Random.Range(minLifetime, maxLifetime);
    }
}