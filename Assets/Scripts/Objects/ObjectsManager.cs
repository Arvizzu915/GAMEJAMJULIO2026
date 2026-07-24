using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectsManager : MonoBehaviour
{
    [SerializeField] private LanchaManager lanchaManager;

    private void Start()
    {

    }

    public void UseObject(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {

        }
    }
}
