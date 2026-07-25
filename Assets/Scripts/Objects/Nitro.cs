using UnityEngine;

[CreateAssetMenu(fileName = "Object", menuName = "Object/nitro")]
public class Nitro : ObjectSO
{
    [SerializeField] private float nitroForce = 5;

    public override void Use(LanchaManager manager)
    {
        Debug.Log("Nitro");
        manager.lanchaMovement.rb.AddForce(manager.transform.up * nitroForce, ForceMode2D.Impulse);
    }
}
