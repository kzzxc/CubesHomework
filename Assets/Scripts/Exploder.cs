using System;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public event Action<Transform> Exploded;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.TryGetComponent(out Cube cube))
                {
                    Exploded?.Invoke(cube.transform);
                    Explode(cube.gameObject);
                }
            }
        }
    }

    private void Explode(GameObject Object)
    {
        Vector3 explosionPos = Object.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, _explosionRadius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(_explosionForce, explosionPos, _explosionRadius);
            }
        }

        Destroy(Object);
    }
}
