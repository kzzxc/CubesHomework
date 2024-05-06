using UnityEngine;

namespace Explosion
{
    public class Cube : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;

        private float _chanñeOfSplitting = 100f;
        public float ChanceOfSplitting => _chanñeOfSplitting;

        public void Initialize(Vector3 newScale, float chanñeOfSplitting)
        {
            transform.localScale = newScale;
            _renderer.material.color = Random.ColorHSV();
            _chanñeOfSplitting = chanñeOfSplitting;
        }
    }
}
