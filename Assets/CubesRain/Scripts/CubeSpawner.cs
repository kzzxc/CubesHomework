using UnityEngine;

public class CubeSpawner : CubesPool
{
    [SerializeField] private Cube[] _ObjectTemplates;
    [SerializeField] private float _secnodsBetweenSpawn;

    private float _elapserTime = 0;

    private int _minValueX = -15;
    private int _maxValueX = 16;

    private int _minValueY = 15;
    private int _maxValueY = 15;

    private int _minValueZ = -15;
    private int _maxValueZ = 16;

    private void Start() => Initialize(_ObjectTemplates);

    private void Update()
    {
        _elapserTime += Time.deltaTime;

        if (_elapserTime > _secnodsBetweenSpawn)
        {
            if (TryGetObject(out Cube spawnableObject))
            {
                _elapserTime = 0;

                SetObject(spawnableObject);
            }
        }
    }

    private void SetObject(Cube spawnableObject)
    {
        spawnableObject.gameObject.SetActive(true);
        spawnableObject.transform.position = GetRandomSpawnPosition();
    }

    private Vector3 GetRandomSpawnPosition()
    {
        int spawnPointX = Random.Range(_minValueX, _maxValueX);
        int spawnPointY = Random.Range(_minValueY, _maxValueY);
        int spawnPointZ = Random.Range(_minValueZ, _maxValueZ);

        return new Vector3(spawnPointX, spawnPointY, spawnPointZ);
    }
}
