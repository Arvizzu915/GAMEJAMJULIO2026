using UnityEngine;
using UnityEngine.InputSystem;

public class LanchaMovementSimple : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float acceleration;

    Vector2 direction = Vector2.zero;

    private SimpleMovement SimpleMove;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SimpleMove = new SimpleMovement();
        SimpleMove.Enable();
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = SimpleMove.Keyboard.Drive.ReadValue<Vector2>();
        
        
    }

    private void FixedUpdate()
    {
        Drive(direction);
    }

    void Drive(Vector2 direction)
    {
        rb.AddForce(direction*acceleration*Time.fixedDeltaTime);
    }
}
