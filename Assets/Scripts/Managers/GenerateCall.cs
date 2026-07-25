using UnityEngine;

public class GenerateCall : MonoBehaviour
{
    private void OnEnable()
    {
        LevelManager.singleton.GenerateLevel();
    }
}
