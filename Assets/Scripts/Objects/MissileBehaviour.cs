using UnityEngine;

public class MissileBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Animator animator;

    private void Awake()
    {
        TryGetComponent(out rb);
        TryGetComponent(out animator);
    }

    public void OnSpawn(Vector3 shootDir)
    {
        rb.AddForce(shootDir * speed, ForceMode2D.Impulse);
        animator.Play("MissileIdle");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDestructible destructible))
        {
            destructible.DestroyObject();
            rb.linearVelocity = Vector3.zero;
            animator.Play("Explosion");
        }
    }

    public void OnDespawn()
    {
        Destroy(gameObject);
    }
}
