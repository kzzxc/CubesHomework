using UnityEngine;

namespace Explosion
{
    public class Cube : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;

        private float _chan�eOfSplitting = 100f;
        public float ChanceOfSplitting => _chan�eOfSplitting;

        public void Initialize(Vector3 newScale, float chan�eOfSplitting)
        {
            transform.localScale = newScale;
            _renderer.material.color = Random.ColorHSV();
            _chan�eOfSplitting = chan�eOfSplitting;
        }
    }
}
