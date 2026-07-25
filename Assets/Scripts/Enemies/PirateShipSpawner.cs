using UnityEngine;

public class PirateShipSpawner : MonoBehaviour
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
        int leftOrRight = Random.Range(0, 2);
        float xPos = 0;
        float diePos = 0;
        bool isRight;
        if (leftOrRight == 0)
        {
            xPos = LevelManager.singleton.mapLeftDownPoint.x - 1;
            diePos = LevelManager.singleton.mapRightTopPoint.x + 1;
            isRight = true;
        }
        else
        {
            xPos = LevelManager.singleton.mapRightTopPoint.x + 1;
            diePos = LevelManager.singleton.mapLeftDownPoint.x - 1;
            isRight = false;
        }
        Vector2 spawnPos = new Vector2(xPos, LevelManager.singleton.GetRandomRow());
        GameObject newShip = Instantiate(shipPrefab, spawnPos, Quaternion.identity);
        newShip.GetComponent<PirateShip>().OnSpawn(isRight, diePos);
    }
}
