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
        float t = .5f*Time.deltaTime;
        Quaternion targetRotation= Quaternion.Euler(new Vector3(0, 0, RotationDirection(direction)));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation,300*Time.deltaTime);
        
        
    }

    private void FixedUpdate()
    {
        Drive(direction);
    }

    void Drive(Vector2 direction)
    {
        rb.AddForce(direction*acceleration*Time.fixedDeltaTime);
    }

    float RotationDirection(Vector2 direction)
    {

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        return angle;
    }
}
