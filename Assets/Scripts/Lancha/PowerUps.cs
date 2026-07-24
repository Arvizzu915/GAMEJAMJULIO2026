using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public float powerMeter = 0, powerLimit;

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
        }
    }

    public void GetPower(int power)
    {
        powerMeter += power;

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
}
