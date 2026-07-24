using UnityEngine;

public class GenteManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] genteSpots;
    [SerializeField] private int currentGente = 0, powerMeter = 0, powerLimit = 10;

    public void PickUpGente()
    {
        genteSpots[currentGente].enabled = true;

        currentGente++;
        powerMeter++;

        if (powerMeter >= powerLimit)
        {
            PowerUp();
        }
    }

    private void PowerUp()
    {
        //power up
    }

    public void Crash(int Damage)
    {
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
