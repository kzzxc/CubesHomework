using System;
using UnityEngine;

public class CubeCollisionHandler : MonoBehaviour
{
    public event Action Fall;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent(out Platform platform))
            Fall?.Invoke();
    }
}
