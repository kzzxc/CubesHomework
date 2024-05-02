using System;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] public float _explosionRadius;

    public event Action<Cube> Exploded;

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
                    Exploded?.Invoke(cube);
                    Destroy(cube.gameObject);
                }
            }
        }
    }

    public void Explode(Transform cube)
    {
        Vector3 explosionPos = cube.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, CalculateExplosionRadius(cube));

        foreach (Collider nearbyObject in colliders)
        {
            ApplyExplosionForce(nearbyObject.transform, explosionPos);
        }
    }

    public void ApplyExplosionForce(Transform cubeTransform, Vector3 explosionPos)
    {
        Rigidbody cubeRigidbody = cubeTransform.GetComponent<Rigidbody>();

        if (cubeRigidbody != null)
        {
            cubeRigidbody.AddExplosionForce(CalculateExplosionForce(cubeTransform), explosionPos, CalculateExplosionRadius(cubeTransform));
        }
    }

    private float CalculateExplosionForce(Transform cube) => CalculateExplosionParameter(cube, _explosionForce);

    private float CalculateExplosionRadius(Transform cube) => CalculateExplosionParameter(cube, _explosionRadius);

    private float CalculateExplosionParameter(Transform cubeTransform, float parameter)
    {
        Vector3 cubeScale = cubeTransform.localScale;
        float cubeSize = Mathf.Max(cubeScale.x, cubeScale.y, cubeScale.z);

        float result = parameter / cubeSize;

        return result;
    }
}
