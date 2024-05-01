using UnityEngine;

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
            Split(cube.transform);
    }

    private void Split(Transform cube)
    {
        int numberOfCubees = Random.Range(_minCubes, _maxCubes);

        if (CanSplit())
        {
            Vector3 cubeScale = cube.localScale / _scaleReduce;
            float currentChanñeOfSplitting = _cube.ChanñeOfSplitting / _chanceReduce;

            for (int i = 0; i <= numberOfCubees; i++)
            {
                var newCube = Instantiate(_cube, cube.position, cube.rotation);
                newCube.Initialize(cubeScale, currentChanñeOfSplitting);
                ApplyExplosionForce(newCube.transform);
            }
        }
    }

    private bool CanSplit()
    {
        var chance = Random.Range(_minChanceOfSplitting, _maxChanceOfSplitting);
        
        return _cube.ChanñeOfSplitting > chance ? true : false;
    }

    private void ApplyExplosionForce(Transform cubeTransform)
    {
        Rigidbody cubeRigidbody = cubeTransform.GetComponent<Rigidbody>();

        if(cubeRigidbody != null)
        {
            cubeRigidbody.AddExplosionForce(1200f, cubeTransform.position, 20f);
        }
    }
}
