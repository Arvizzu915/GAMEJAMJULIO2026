using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectsManager : MonoBehaviour
{
    [SerializeField] private LanchaManager lanchaManager;

    public ObjectSO[] currentObject;

    public GameObject[] objectSlotsUI;

    public int[] currentObjectsUses;

    public int currentUsedSlots = 0;

    private void Start()
    {
        InputManager.Instance.inputs.Keyboard.Use.performed += UseObject;
    }

    public void UseObject(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            for (int i = 0; i < currentObject.Length; i++)
            {
                if (currentObject[i] != null && currentObjectsUses[i] > 0)
                {
                    currentObject[i].Use(lanchaManager);
                    currentObjectsUses[i]--;
                    if (currentObjectsUses[i] <= 0)
                    {
                        currentObject[i] = null;
                        currentUsedSlots--;
                    }
                    return;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (currentUsedSlots == 3) return;

        if (collision.CompareTag("Object"))
        {
            SetObjectSlot(collision.GetComponent<Weapon>().objectSO);
            collision.gameObject.SetActive(false);
        }
    }

    private void SetObjectSlot(ObjectSO weapon)
    {
        for (int i = 0; i < currentObject.Length; i++)
        {
            if (currentObject[i] == null)
            {
                currentObject[i] = weapon;
                objectSlotsUI[i].SetActive(true);
                currentUsedSlots++;
                currentObjectsUses[i] = weapon.maxUses;
                return;
            }
        }
    }
}
