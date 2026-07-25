using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
public class PirateShip : MonoBehaviour
{
    [SerializeField] private float speed, bombInterval;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Animator animator;
    private Rigidbody2D rb;
    private float bombIntervalCount, orientation, diePos;

    private void Awake()
    {
        TryGetComponent(out rb);
    }

    public void OnSpawn(bool isGoingRight, float diePos)
    {
        if (isGoingRight)
        {
            orientation = 1f;
            sr.flipX = true;
        }
        else
        {

            orientation = -1f;
            sr.flipX = false;
        }
        animator.Play("ShipIdle");
        this.diePos = diePos;
        bombIntervalCount = 0f;
    }

    private void Update()
    {
        bombIntervalCount += Time.deltaTime;
        if (bombIntervalCount >= bombInterval)
        {
            bombIntervalCount = 0f;
            animator.Play("ShipShoot");
        }
    }

    private void FixedUpdate()
    {
        Move();
        CheckDeath();
    }

    private void Move()
    {
        rb.MovePosition(transform.position + transform.right * orientation * speed * Time.fixedDeltaTime);
    }

    private void CheckDeath()
    {
        if (orientation == 1f && transform.position.x >= diePos)
            Die();
        else if (orientation == -1f && transform.position.x <= diePos)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
