using UnityEngine;

public class Shark : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float activeTime;
    private float activeTimeCount;

    public void OnSpawn()
    {
        gameObject.SetActive(true);
        activeTimeCount = 0;
    }

    private void Update()
    {
        activeTimeCount += Time.deltaTime;
        if (activeTimeCount >= activeTime)
            ObstaclePool.singleton.ReturnSharkToPool(this);
    }
}
