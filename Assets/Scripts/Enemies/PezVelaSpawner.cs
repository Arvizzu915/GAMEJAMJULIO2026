using UnityEngine;

public class PezVelaSpawner : MonoBehaviour
{
    [SerializeField] private GameObject shipPrefab;
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
            SpawnShip();
            spawnRateTimer = Random.Range(-spawnRandomDifference, spawnRandomDifference);
        }
    }

    private void SpawnShip()
    {
        Instantiate(shipPrefab);
    }
}
