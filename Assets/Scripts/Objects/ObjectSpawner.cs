using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsPrefabs;
    [SerializeField] private float spawnRate, spawnRandomDifference;
    private float spawnRateTimer;

    private void Awake()
    {
        spawnRateTimer = 0f;
    }

    private void Update()
    {
        spawnRateTimer += Time.deltaTime;
        if (spawnRateTimer >= spawnRate)
        {
            SpawnObjects();
            spawnRateTimer = Random.Range(-spawnRandomDifference, spawnRandomDifference);
        }
    }

    private void SpawnObjects()
    {
        GameObject newObject = Instantiate(objectsPrefabs[Random.Range(0, objectsPrefabs.Length)], LevelManager.singleton.GetRandomAvailableSpot(), Quaternion.identity);
    }
}
