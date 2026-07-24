using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
public class PirateShip : MonoBehaviour
{
    [SerializeField] Transform mapLeftDownPoint, mapRightTopPoint;
    [SerializeField] Tilemap mapTilemap;
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

    private Vector3 GetBombPosition()
    {
        float xPos = Random.Range(mapLeftDownPoint.position.x, mapRightTopPoint.position.x);
        float yPos = Random.Range(mapLeftDownPoint.position.y, mapRightTopPoint.position.y);

        //Esto ajusta la posicion al grid/tilemap
        Vector3Int gridPos = mapTilemap.WorldToCell(new Vector2(xPos, yPos));
        Vector3 adjustedPos = mapTilemap.CellToWorld(gridPos);
        adjustedPos.x += 0.5f;
        adjustedPos.y += 0.5f;

        return (adjustedPos);
    }

    private void DropBomb()
    {
        Vector3 bombPos = Vector3.zero;
        for (int i = 0; i < 20; i++)
        {
            bombPos = GetBombPosition();
            if (BombPool.singleton.IsPositionEmpty(bombPos))
                break;
            if (i == 19)
                return;
        }
        Bomb newBomb = BombPool.singleton.GetBomb();
        newBomb.transform.position = bombPos;
        newBomb.StartLife();
    }

    private void Move()
    {
        rb.MovePosition(transform.position + transform.up * speed * Time.fixedDeltaTime);
    }
}
