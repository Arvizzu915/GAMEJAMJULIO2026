using UnityEngine;
using UnityEngine.InputSystem;

public class LanchaMovementSimple : MonoBehaviour
{
    public GameObject boatModel;
    public Rigidbody2D rb;
    public float speedBoost = 1;
    [SerializeField] private float acceleration;

    public Vector2 direction = Vector2.zero;

    InputAction move;

    private void Start()
    {
        move = InputManager.Instance.inputs.Keyboard.Drive;
    }

    // Update is called once per frame
    void Update()
    {
        direction = move.ReadValue<Vector2>();
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
        rb.AddForce(direction * acceleration * speedBoost * Time.fixedDeltaTime);
    }

    float RotationDirection(Vector2 direction)
    {

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        return angle;
    }
}
