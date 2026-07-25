using UnityEngine;

public class Bomb : MonoBehaviour, IDestructible
{
    [SerializeField] private float activeTime;
    private Animator animator;
    private float activeTimeCount;

    private void Awake()
    {
        TryGetComponent(out animator);
    }

    public void StartLife()
    {
        gameObject.SetActive(true);
        animator.Play("BombDrop");
        activeTimeCount = 0;
    }

    private void Update()
    {
        activeTimeCount += Time.deltaTime;
        if (activeTimeCount >= activeTime)
            animator.Play("BombLeave");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out GenteManager vida))
            animator.Play("Explosion");
    }

    public void Despawn()
    {
        ObstaclePool.singleton.ReturnBombToPool(this);
    }

    public void DestroyObject()
    {
        Despawn();
    }
}
