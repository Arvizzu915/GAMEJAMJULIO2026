using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public SimpleMovement SimpleMove;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;

        SimpleMove = new SimpleMovement();
        SimpleMove.Enable();

    }

    private void Start()
    {
        SimpleMove.Keyboard.Restart.performed += Restart;
    }

    public void Restart(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            SceneManager.LoadScene(0);
        }
    }
}
