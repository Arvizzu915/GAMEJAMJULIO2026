using UnityEngine;

public class GenteManager : MonoBehaviour
{
    public static GenteManager instance;

    [SerializeField] private SpriteRenderer[] genteSpots;
    public int currentGente = 0, powerMeter = 0, powerLimit = 10;

    [SerializeField] private PowerUps powerUpManager;
    public bool hasBubble = false;

    private void Awake()
    {
        instance = this;
    }

    public void PickUpGente(int power)
    {
        genteSpots[currentGente].enabled = true;

        currentGente++;

        powerUpManager.GetPower(power);

        LevelManager.singleton.peopleRescued++;
    }

    public void Crash(int Damage)
    {
        if (hasBubble)
        {
            hasBubble = false;
            return;
        }
        if (currentGente <= 0)
        {
            //lose
            return;
        }

        for (int i = 0; i < Damage; i++)
        {
            currentGente--;
            genteSpots[currentGente].enabled = false;
        }
    }
}
