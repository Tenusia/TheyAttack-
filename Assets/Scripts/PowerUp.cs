using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerupEffect powerupEffect;
    
    void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.GetComponent<Health>() != null && collision.GetComponent<Health>().isPlayer)
        {
            //if(!collision.GetComponent<Health>().isPlayer) {return;}
            Destroy(gameObject);
            powerupEffect.Apply(collision.gameObject);
        }
        
    }
}
