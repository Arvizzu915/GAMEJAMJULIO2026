using UnityEngine;

public class ObstaclesInMapManager : MonoBehaviour
{
    public static ObstaclesInMapManager singleton;

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
