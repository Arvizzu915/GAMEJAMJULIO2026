using UnityEngine;

[CreateAssetMenu(fileName = "Object", menuName = "Object/godMode")]
public class GodModeSO : ObjectSO
{
    public override void Use(LanchaManager manager)
    {
        //instantiate a missile from missile pool
        manager.ActivateGodMode();
    }
}
