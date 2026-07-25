using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public GenericPool gentePool;

    public int peopleRescuedSoFar = 0;
    public float timeSoFar = 0;

    public GameObject panelLose;
    public TextMeshProUGUI time, points;

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

    public void Lose()
    {
        time.text = timeSoFar.ToString();
        points.text = peopleRescuedSoFar.ToString();

        panelLose.SetActive(true);
    }

    public void RegisterLevelData(int people, float Time)
    {
        peopleRescuedSoFar += people;
        timeSoFar += Time;
    }
}
