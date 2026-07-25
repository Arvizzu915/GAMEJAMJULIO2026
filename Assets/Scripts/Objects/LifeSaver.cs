using UnityEngine;

public class LifeSaver : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;

    private void Awake()
    {
        TryGetComponent(out rb);
    }

    public void OnSpawn(Vector3 shootDir)
    {
        rb.AddForce(shootDir * speed, ForceMode2D.Impulse);
    }
}
