using UnityEngine;

public class SharkSpawner : MonoBehaviour
{
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
            SpawnShark();
            spawnRateTimer = Random.Range(-spawnRandomDifference, spawnRandomDifference);
        }
    }

    private void SpawnShark()
    {
        Shark newShark = ObstaclePool.singleton.GetShark();
        newShark.transform.position = LevelManager.singleton.GetRandomAvailableSpot();
        newShark.OnSpawn();
    }
}
