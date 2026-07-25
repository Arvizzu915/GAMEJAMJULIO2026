using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
public class PirateShip : MonoBehaviour
{
    [SerializeField] private float speed, bombInterval;
    private Rigidbody2D rb;
    private float bombIntervalCount;

    private void Awake()
    {
        TryGetComponent(out rb);
        bombIntervalCount = 0f;
    }

    private void Update()
    {
        bombIntervalCount += Time.deltaTime;
        if (bombIntervalCount >= bombInterval)
        {
            bombIntervalCount = 0f;
            DropBomb();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void DropBomb()
    {
        Bomb newBomb = ObstaclePool.singleton.GetBomb();
        newBomb.transform.position = LevelManager.singleton.GetRandomAvailableSpot();
        newBomb.StartLife();
    }

    private void Move()
    {
        rb.MovePosition(transform.position + transform.up * speed * Time.fixedDeltaTime);
    }
}
