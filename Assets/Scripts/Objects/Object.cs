using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Weapon : MonoBehaviour
{
    public abstract void Use(LanchaManager manager);
}
