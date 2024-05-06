using System.Collections;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;

    private int _minValueX = -15;
    private int _maxValueX = 16;

    private int _minValueY = 5;
    private int _maxValueY = 15;

    private int _minValueZ = -15;
    private int _maxValueZ = 16;

    private WaitForSeconds _wait = new WaitForSeconds(0.8f);

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(_prefab, GetSpawnPointPosition(), Quaternion.identity);
            yield return _wait;
        }
    }

    private Vector3 GetSpawnPointPosition()
    {
        int spawnPointX = Random.Range(_minValueX, _maxValueX);
        int spawnPointY = Random.Range(_minValueY, _maxValueY);
        int spawnPointZ = Random.Range(_minValueZ, _maxValueZ);

        return new Vector3(spawnPointX, spawnPointY, spawnPointZ);
    }
}
