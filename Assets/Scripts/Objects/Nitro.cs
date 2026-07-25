using UnityEngine;

[CreateAssetMenu(fileName = "Object", menuName = "Object/nitro")]
public class Nitro : ObjectSO
{
    [SerializeField] private float nitroForce = 5;

    public override void Use(LanchaManager manager)
    {
        manager.lanchaMovement.rb.AddForce(manager.lanchaMovement.direction * nitroForce, ForceMode2D.Impulse);
    }
}
