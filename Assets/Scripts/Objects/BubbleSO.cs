using UnityEngine;

[CreateAssetMenu(fileName = "Object", menuName = "Object/bubble")]
public class BubbleSO : ObjectSO
{
    public override void Use(LanchaManager manager)
    {
        manager.genteManager.hasBubble = true;
    }
}
