using UnityEngine;

public class GenteManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] genteSpots;
    [SerializeField] private int currentGente = 0, powerMeter = 0, powerLimit = 10;

    [SerializeField] private PowerUps powerUpManager;
    public bool hasBubble = false;

    public void PickUpGente(int power)
    {
        genteSpots[currentGente].enabled = true;

        currentGente++;

        powerUpManager.GetPower(power);
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
