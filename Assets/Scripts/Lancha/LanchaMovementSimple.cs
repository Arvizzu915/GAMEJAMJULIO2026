using UnityEngine;
using UnityEngine.InputSystem;

public class LanchaMovementSimple : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speedBoost = 1;
    [SerializeField] private float acceleration;

    public Vector2 direction = Vector2.zero;
    Vector2 movedir;
    float rotationAngle;

    InputAction move;

    private void Start()
    {
        move = InputManager.Instance.inputs.Keyboard.Drive;
    }

    // Update is called once per frame
    void Update()
    {
        direction = move.ReadValue<Vector2>();
        
        if (direction != Vector2.zero)
        {
        movedir = direction;
            
        }
        
        float t = .5f*Time.deltaTime;
        if (movedir != Vector2.zero)
        {
            
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, RotationAngle(movedir)));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 300 * Time.deltaTime);

        }
        
        
        
        
    }

    private void FixedUpdate()
    {
        Drive(direction);
    }

    void Drive(Vector2 direction)
    {
        rb.AddForce(direction * acceleration * speedBoost * Time.fixedDeltaTime);
    }

    float RotationAngle(Vector2 inputDirection)
    {
        float angle = Mathf.Atan2(inputDirection.y, inputDirection.x) * Mathf.Rad2Deg;

        return angle;
    }
}
