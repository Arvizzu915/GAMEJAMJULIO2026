using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public SimpleMovement inputs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;

        inputs = new SimpleMovement();
        inputs.Enable();

    }


    private void Start()
    {
        inputs.Keyboard.Restart.performed += Restart;
    }

    public void Restart(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            SceneManager.LoadScene(0);
        }
    }
}
