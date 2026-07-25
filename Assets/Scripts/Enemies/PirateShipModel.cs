using UnityEngine;

public class PirateShipModel : MonoBehaviour
{
    public void DropBomb()
    {
        Bomb newBomb = ObstaclePool.singleton.GetBomb();
        newBomb.transform.position = LevelManager.singleton.GetRandomAvailableSpot();
        newBomb.StartLife();
    }
}
