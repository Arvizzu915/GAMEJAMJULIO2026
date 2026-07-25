using UnityEngine;

[CreateAssetMenu(fileName = "Object", menuName = "Object/lifesaver")]
public class LifesaverSO : ObjectSO
{
    public override void Use(LanchaManager manager)
    {
        //instantiate a missile from missile pool
        GameObject newLifesaver = manager.lifesaverPool.GetObject(manager.transform.position);
        newLifesaver.transform.rotation = manager.transform.rotation;
        newLifesaver.GetComponent<LifeSaver>().OnSpawn(manager.transform.up);
    }
}
