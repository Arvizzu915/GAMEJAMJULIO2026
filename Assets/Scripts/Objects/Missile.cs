using UnityEngine;

[CreateAssetMenu(fileName = "Object", menuName = "Object/missile")]
public class Missile : ObjectSO
{
    public override void Use(LanchaManager manager)
    {
        //instantiate a missile from missile pool
        GameObject newMissile = manager.missilePool.GetObject(manager.transform.position);
        newMissile.transform.rotation = manager.transform.rotation;
        newMissile.GetComponent<MissileBehaviour>().OnSpawn(manager.transform.up);
    }
}
