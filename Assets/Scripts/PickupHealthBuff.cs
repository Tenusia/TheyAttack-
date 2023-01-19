using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/HealthBuff")]
public class PickupHealthBuff : PowerupEffect
{
    public int amount;
    
    public override void Apply(GameObject target)
    {
        target.GetComponent<Health>().health += amount;
    }
}
