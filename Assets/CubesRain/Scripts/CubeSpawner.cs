using UnityEngine;

public class CubeSpawner : Pool<Cube>
{
    [SerializeField] private float _secnodsBetweenSpawn;
    
    private float _elapsedTime;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secnodsBetweenSpawn && TryGetObject(out Cube spawnableObject))
        {
            _elapsedTime = 0;

            SetObject(spawnableObject);
        }
    }

    private void SetObject(Cube spawnableObject)
    {
        spawnableObject.gameObject.SetActive(true);
        spawnableObject.transform.position = GetRandomSpawnPosition();
    }

    private Vector3 GetRandomSpawnPosition()
    {
        int minValueX = -14;
        int maxValueX = 17;
        int minValueZ = -14;
        int maxValueZ = 17;
        
        int spawnPointX = Random.Range(minValueX, maxValueX);
        int spawnPointZ = Random.Range(minValueZ, maxValueZ);
        int spawnPointY = 30;

        return new Vector3(spawnPointX, spawnPointY, spawnPointZ);
    }
}