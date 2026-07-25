using UnityEngine;


public abstract class ObjectSO : ScriptableObject
{
    public int maxUses;
    public abstract void Use(LanchaManager manager);
}
