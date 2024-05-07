using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private CubeCollisionHandler _collisionHandler;
    [SerializeField] private Renderer _renderer;

    private Coroutine _currentCoroutine;

    private void OnEnable()
    {
        _collisionHandler.Falled += OnFalled;
        _renderer.material.color = Color.white;
    }

    private void OnDisable()
    {
        _collisionHandler.Falled -= OnFalled;

        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
            _currentCoroutine = null;
        }
    }

    private void OnFalled()
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
    }

    private int GetLifetime()
    {
        int minLifetime = 2;
        int maxLifetime = 5;

        return Random.Range(minLifetime, maxLifetime);
    }
}
