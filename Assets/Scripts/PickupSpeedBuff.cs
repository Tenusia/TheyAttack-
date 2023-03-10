using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/SpeedBuff")]
public class PickupSpeedBuff : PowerupEffect
{
    float originalSpeed;
    public float amount;
    public float boostDuration = 3f;

    public override void Apply(GameObject target)
    {
        originalSpeed = target.GetComponent<Player>().moveSpeed;
        target.GetComponent<Player>().moveSpeed += amount;
        //Add coroutine in Player for a wait. See also RapidFire pickup script.
    }
}
