using UnityEngine;

public class LanchaManager : MonoBehaviour
{
    public GenteManager genteManager;
    public LanchaMovementSimple lanchaMovement;
    public GenericPool missilePool, lifesaverPool;

    [SerializeField] private float godModeTime = 5f, objectSpawnerTime = 0.7f, angleRotation = 10f, speedBoost = 2f;
    private SpriteRenderer bubbleRenderer;
    private Vector3 objectShootDir;
    private float godModeTimeCount, objectSpawnerTimeCount;
    private bool isGodMode;

    public void ActivateGodMode()
    {
        bubbleRenderer = genteManager.bubbleAnimator.GetComponent<SpriteRenderer>();
        objectShootDir = Quaternion.AngleAxis(angleRotation, Vector3.forward) * transform.up;
        lanchaMovement.speedBoost = speedBoost;
        godModeTimeCount = 0;
        objectSpawnerTimeCount = 0;
        isGodMode = true;
    }

    private void EndGodMode()
    {
        lanchaMovement.speedBoost = 1f;
        isGodMode = false;
    }

    private void Update()
    {
        if (!isGodMode) return;
        godModeTimeCount += Time.deltaTime;
        objectSpawnerTimeCount += Time.deltaTime;

        if (objectSpawnerTimeCount >= objectSpawnerTime)
        {
            ShootObjects();
            objectShootDir = Quaternion.AngleAxis(angleRotation, Vector3.forward) * objectShootDir;
            objectSpawnerTimeCount = 0f;
        }
        CheckBubble();
        if (godModeTimeCount >= godModeTime)
            EndGodMode();
    }

    private void CheckBubble()
    {
        if (!bubbleRenderer.enabled)
            genteManager.ToggleBubble(true);
    }

    private void ShootObjects()
    {
        GameObject newMissile = missilePool.GetObject(transform.position);
        newMissile.transform.rotation = Quaternion.LookRotation(transform.forward, objectShootDir);
        newMissile.GetComponent<MissileBehaviour>().OnSpawn(newMissile.transform.up);

        GameObject newLifesaver = lifesaverPool.GetObject(transform.position);
        newLifesaver.transform.rotation = Quaternion.LookRotation(transform.forward, objectShootDir * -1f);
        newLifesaver.GetComponent<LifeSaver>().OnSpawn(newLifesaver.transform.up);
    }
}
