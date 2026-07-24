using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectsManager : MonoBehaviour
{
    [SerializeField] private LanchaManager lanchaManager;

    private Weapon currentObject = null;

    private void Start()
    {
        InputManager.Instance.SimpleMove.Keyboard.Use.performed += UseObject;
    }

    public void UseObject(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            currentObject.Use(lanchaManager);
        }
    }
}
