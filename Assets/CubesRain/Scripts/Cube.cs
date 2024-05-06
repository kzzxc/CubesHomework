using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private CubeCollisionHandler _collisionHandler;
    [SerializeField] private Renderer _renderer;

    private Coroutine _currentCoroutine;

    private int _minLifetime = 2;
    private int _maxLifetime = 5;
    private int _lifetime = 1;

    private WaitForSeconds _secondWait = new WaitForSeconds(1);

    private void Update()
    {
        if (_lifetime <= 0)
        {
            StopCoroutine(_currentCoroutine);
            Destroy(gameObject);
        }
    }

    private void OnEnable() => _collisionHandler.Falled += OnFalled;

    private void OnDisable() => _collisionHandler.Falled -= OnFalled;

    private void OnFalled()
    {
        if (_currentCoroutine == null)
            _currentCoroutine = StartCoroutine(LifeTimer());
    }

    public IEnumerator LifeTimer()
    {
        _lifetime = Random.Range(_minLifetime, _maxLifetime);
        _renderer.material.color = Random.ColorHSV();

        while (_lifetime > 0)
        {
            _lifetime--;
            yield return _secondWait;
        }
    }
}
