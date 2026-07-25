using UnityEngine;

public class Gente : MonoBehaviour
{
    private int powerMeter = 1;
    [SerializeField] private float drownTime = 8f;
    private float drownTimer = 0;

    private bool active = false;

    [SerializeField] private AnimatorOverrideController[] animOverrides;
    [SerializeField] private Animator animator;

    private void OnEnable()
    {
        drownTimer = Time.time;
        active = true;
        SetSkins();
        animator.Play("idle");
    }

    private void Update()
    {
        if (!active) return;

        if (Time.time - drownTimer >= drownTime)
        {
            Drown();
        }
    }

    private void Drown()
    {
        animator.Play("drown");
    }

    public void ReturnToPool()
    {
        ScoreManager.instance.gentePool.ReturnObject(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<GenteManager>().PickUpGente(powerMeter);
            gameObject.SetActive(false);
        }
    }

    public void SetSkins()
    {
        int index = Random.Range(0, animOverrides.Length);

        animator.runtimeAnimatorController = animOverrides[index];
    }
}
