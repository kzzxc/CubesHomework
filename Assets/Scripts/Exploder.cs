using System;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

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
}
