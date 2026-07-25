using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int peopleRescuedSoFar = 0;
    public float timeSoFar = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void RegisterLevelData(int people, float Time)
    {
        peopleRescuedSoFar += people;
        timeSoFar += Time;
    }
}
