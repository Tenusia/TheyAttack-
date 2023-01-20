using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFireBullets : MonoBehaviour
{
    [SerializeField] int bulletsAmount = 10;
    [SerializeField] float startAngle = 90f, endAngle = 270f;
    [SerializeField] float firingRate = 2f;
    Vector2 bulletMoveDirection;
    AudioPlayer audioPlayer;

    void Awake() 
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();    
    }

    void Start()
    {
        audioPlayer.TurnOffAudioSource();
        InvokeRepeating("Fire", 2f, firingRate);    
    }

    void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDiry = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDiry, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<BossBullet>().SetMoveDirection(bulDir);

            angle += angleStep;
            audioPlayer.PlayGunPoolClip();
        }

    }
}
