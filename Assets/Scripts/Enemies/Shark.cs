using UnityEngine;

public class Shark : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float activeTime;
    private Animator animator;
    private float activeTimeCount;

    private void Awake()
    {
        TryGetComponent(out animator);
    }

    public void OnSpawn()
    {
        gameObject.SetActive(true);
        animator.Play("SharkIdle");
        activeTimeCount = 0;
    }

    private void Update()
    {
        activeTimeCount += Time.deltaTime;
        if (activeTimeCount >= activeTime)
        {
            animator.Play("SharkBite");
        }
    }

    public void OnDespawn()
    {
        ObstaclePool.singleton.ReturnSharkToPool(this);
    }
}
