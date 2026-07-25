using UnityEngine;

public class PezVelaObject : MonoBehaviour
{
    PezVelaManager manager;

    [SerializeField] Rigidbody2D rb;

    public void Fly(PezVelaManager pezVelaManager, float speed)
    {
        transform.SetParent(null, true);

        manager = pezVelaManager;

        rb.linearVelocity = Vector2.left * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<GenteManager>().Crash(2);
        }

        manager.Deactivate();
    }

}
