using UnityEngine;

[CreateAssetMenu(fileName = "Object", menuName = "Object/missile")]
public class Missile : ObjectSO
{
    public override void Use(LanchaManager manager)
    {
        //instantiate a missile from missile pool
        GameObject newMissile = manager.missilePool.GetObject(manager.lanchaMovement.boatModel.transform.position);
        newMissile.transform.rotation = manager.lanchaMovement.boatModel.transform.rotation;
        newMissile.GetComponent<MissileBehaviour>().OnSpawn(manager.lanchaMovement.boatModel.transform.up);
    }
}
