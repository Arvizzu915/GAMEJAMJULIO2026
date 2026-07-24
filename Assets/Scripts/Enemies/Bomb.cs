using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float activeTime;
    private float activeTimeCount;

    public void StartLife()
    {
        gameObject.SetActive(true);
        activeTimeCount = 0;
    }

    private void Update()
    {
        activeTimeCount += Time.deltaTime;
        if (activeTimeCount >= activeTime)
            BombPool.singleton.ReturnToPool(this);
    }
}
