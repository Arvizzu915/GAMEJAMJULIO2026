using UnityEngine;
using UnityEngine.InputSystem;

public class LanchaMovementSimple : MonoBehaviour
{
    public Rigidbody2D rb;
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
