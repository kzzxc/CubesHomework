using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    public void Initialize(Vector3 newScale)
    {
        transform.localScale = newScale;
        _renderer.material.color = Random.ColorHSV();
    }
}
