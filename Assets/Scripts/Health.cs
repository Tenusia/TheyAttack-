using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public bool isPlayer;
    [SerializeField] public int health = 50;
    [SerializeField] public int maxHealth = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool ApplyCameraShake;

    public GameObject shield;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;


    void Awake() 
    {     
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();   
        scoreKeeper = FindObjectOfType<ScoreKeeper>(); 
        levelManager = FindObjectOfType<LevelManager>(); 
    }

    void Start() 
    {
        if (shield !=null)
        {
            DeActivateShield();    
        }
    }

    void Update() 
    {
        health = Mathf.Clamp(health, 0, maxHealth);
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(damageDealer != null)
        {
            if(HasShield())
            {
                DeActivateShield();
                //PlayHitEffect();
                ShakeCamera();
            }
            else
            {
                TakeDamage(damageDealer.GetDamage());
                PlayHitEffect();
                audioPlayer.PlayDamageClip();
                ShakeCamera();
                damageDealer.Hit();
            }
        }
    }
    public int GetHealth()
    {
        return health;
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if(!isPlayer)
        {
            scoreKeeper.ModifyScore(score);
        }
        else
        {
            levelManager.LoadGameOver();
        }
        Destroy(gameObject);
    }

    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position,Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if(cameraShake != null && ApplyCameraShake)
        {
            cameraShake.Play();
        }
    }

    public void ActivateShield()
    {
        shield.SetActive(true);
    }

    void DeActivateShield()
    {
        shield.SetActive(false);
    }

    bool HasShield()
    {
        if(shield != null)
        {
            return shield.activeSelf;
        }
        else
        {
            return false;
        }
    }
}
