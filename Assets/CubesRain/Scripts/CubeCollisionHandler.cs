using System;
using UnityEngine;

public class CubeCollisionHandler : MonoBehaviour
{
    public event Action Falled;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent(out Platform platform))
        {
            Falled?.Invoke();
        }
    }
}
