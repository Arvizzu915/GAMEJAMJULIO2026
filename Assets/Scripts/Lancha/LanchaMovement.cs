using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class LanchaMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float acceleration, rotateSpeed;

    
    private InputAction rotate;
    private bool accelerating = false;

    private void Start()
    {
        rotate = InputManager.Instance.inputs.Playing.Rotate;

        InputManager.Instance.inputs.Playing.Accelerate.started += ctx => SetAccelerate(true);
        InputManager.Instance.inputs.Playing.Accelerate.canceled += ctx => SetAccelerate(false);
    }

    private void Update()
    {
       
    }

    private void FixedUpdate()
    {
        rb.AddTorque(rotate.ReadValue<float>() * rotateSpeed);

        if (accelerating)
        {
            rb.AddRelativeForce(Vector2.up * acceleration);
        }
    }

    public void SetAccelerate(bool ctx)
    {
        if (ctx)
        {
            accelerating = true;
        }
        else
        {
            accelerating = false;
        }
    }
}
