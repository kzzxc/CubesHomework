using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] public float _explosionRadius;

    private Renderer _renderer;
    private float _lifetime;
    private float _elapsedTime;

    private void OnEnable()
    {
        _renderer = GetComponent<Renderer>();
        _elapsedTime = 0;
        StartCoroutine(FadeOut());
    }
    
    public void Initialize(float lifetime) => _lifetime = lifetime;

    private IEnumerator FadeOut()
    {
        Color color = _renderer.material.color;

        while (_elapsedTime < _lifetime)
        {
            _elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(1, 0, _elapsedTime / _lifetime);
            _renderer.material.color = color;
            yield return null;
        }

        Explode();
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rigidbody = hit.GetComponent<Rigidbody>();

            if (rigidbody != null)
                rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }

        gameObject.SetActive(false);
    }

    private void OnDrawGizmos()
    {
       Gizmos.color = Color.red;
       Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }
}