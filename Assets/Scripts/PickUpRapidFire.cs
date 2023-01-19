using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/FireBuff")]
public class PickUpRapidFire : PowerupEffect

{  
    public float baseFireAmount;
    public float duration;

    public override void Apply(GameObject target)
    {
        target.GetComponent<Shooter>().rapidFirePickup = baseFireAmount;
        target.GetComponent<Shooter>().rapidFireDuration = duration;
        target.GetComponent<Shooter>().isRapidFiring = true;
    }
}
