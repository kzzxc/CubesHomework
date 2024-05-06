using UnityEngine;

namespace Explosion
{
    public class Splitter : MonoBehaviour
    {
        [SerializeField] private Cube _cube;
        [SerializeField] private Exploder _exploder;

        private int _minCubes = 1;
        private int _maxCubes = 7;

        private float _minChanceOfSplitting = 0f;
        private float _maxChanceOfSplitting = 100f;

        private float _scaleReduce = 2f;
        private float _chanceReduce = 2f;

        private void OnEnable()
        {
            _exploder.Exploded += OnExploded;
        }

        private void OnDestroy()
        {
            _exploder.Exploded -= OnExploded;
        }

        private void OnExploded(Cube cube)
        {
            if (_cube == cube)
            {
                if (CanSplit())
                    Split(cube.transform);
                else
                    _exploder.Explode(cube.transform);
            }
        }

        private void Split(Transform cube)
        {
            int numberOfCubees = Random.Range(_minCubes, _maxCubes);

            Vector3 cubeScale = cube.localScale / _scaleReduce;
            float currentChanñeOfSplitting = _cube.ChanceOfSplitting / _chanceReduce;

            for (int i = 0; i <= numberOfCubees; i++)
            {
                Cube newCube = Instantiate(_cube, cube.position, cube.rotation);
                newCube.Initialize(cubeScale, currentChanñeOfSplitting);
                _exploder.ApplyExplosionForce(newCube.transform, cube.transform.position);
            }
        }

        private bool CanSplit()
        {
            var chance = Random.Range(_minChanceOfSplitting, _maxChanceOfSplitting);

            return _cube.ChanceOfSplitting > chance ? true : false;
        }
    }
}