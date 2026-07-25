using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public float powerMeter = 0, powerLimit;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] LanchaMovementSimple movement;

    

    private bool inRescueTime = false;

    private void Update()
    {
        if (powerMeter <= 0)
        {
            ExitRescueTime();
        }

        if (inRescueTime)
        {
            powerMeter -= .5f*Time.deltaTime;
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
        movement.acceleration = 40000;
        rb.linearDamping = 1.0f;
    }

    private void ExitRescueTime()
    {
        inRescueTime = false;
        powerMeter = 0;
        movement.acceleration = 25000;
        rb.linearDamping = .9f;


    }
}
