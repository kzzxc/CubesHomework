using UnityEngine;

public class CubeSplitter : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private Exploder _exploder;

    private int _minCubes = 1;
    private int _maxCubes = 7;
    private float chanceOfSplitting = 1f;

    private void OnEnable()
    {
        _exploder.Exploded += OnExploded;
    }

    private void OnDisable()
    {
        _exploder.Exploded -= OnExploded;
    }

    private void OnExploded(Transform transform)
    {
        Split(transform);
    }

    private void Split(Transform transform)
    {
        int numberOfCubees = Random.Range(_minCubes, _maxCubes);
        Vector3 cubeScale = transform.localScale / 2f;

        if (Random.value < chanceOfSplitting)
        {
            for (int i = 0; i < numberOfCubees; i++)
            {
                var newCube = Instantiate(_cube, transform.position, transform.rotation);
                newCube.Initialize(cubeScale);
            }

            chanceOfSplitting *= 0.5f;
            Debug.Log(chanceOfSplitting);
        }
    }
}
