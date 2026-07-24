using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public InputActions inputs;

    private void Awake()
    {
        Instance = this;

        inputs = new InputActions();

        inputs.Playing.Enable();
    }

    private void Start()
    {
        inputs.Playing.Restart.performed += Restart;
    }

    public void Restart(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            SceneManager.LoadScene(0);
        }
    }
}
