using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/ShieldPickup")]
public class PickupShield : PowerupEffect
{
    public override void Apply(GameObject target)
    {
        target.GetComponent<Health>().ActivateShield();
    }
}
