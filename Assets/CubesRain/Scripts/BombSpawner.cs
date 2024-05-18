using UnityEngine;

public class BombSpawner : Pool<Bomb>
{
    private void Update() => UpdateCounterText();

    public void SpawnBomb(Vector3 position, float lifetime)
    {
        if (TryGetObject(out Bomb bomb))
        {
            bomb.Initialize(lifetime);
            SetObject(bomb, position);
        }
    }

    private void SetObject(Bomb spawnableObject, Vector3 position)
    {
        spawnableObject.gameObject.SetActive(true);
        spawnableObject.transform.position = position;
    }
}