using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    public float powerMeter = 0, powerLimit;

    Slider powerBar;

    private bool inRescueTime = false;

    private void Update()
    {
        if (powerMeter <= 0)
        {
            ExitRescueTime();
        }

        if (inRescueTime)
        {
            powerMeter -= Time.deltaTime;
            UpdateBar();
        }
    }

    public void GetPower(int power)
    {
        powerMeter += power;
        UpdateBar();
        if (powerMeter >= powerLimit)
        {
            RescueTime();
        }
    }

    private void RescueTime()
    {
        powerMeter = powerLimit;
        inRescueTime = true;
    }

    private void ExitRescueTime()
    {
        inRescueTime = false;
        powerMeter = 0;
    }

    void UpdateBar()
    {
        powerBar.value = powerMeter;
    }
}
