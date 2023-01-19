using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] public float baseFiringRate = 0.2f;

    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float fireRateVarience = 0f;
    [SerializeField] float minimumFireRate = 0.2f;

    [HideInInspector] public bool isFiring;
    [HideInInspector] public bool isRapidFiring;
    [HideInInspector] public float rapidFireDuration;
    [HideInInspector] public float rapidFirePickup;
    float defaultFiringRate;
    float defaultVolume;

    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        defaultFiringRate = baseFiringRate;
    }


    void Start()
    {
        if(useAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
        
        if(isRapidFiring)
        {
            StartCoroutine(RapidFireCoroutine());
        }
        else if(!isRapidFiring)
        {
            StopCoroutine(RapidFireCoroutine());
        }
    }

    void Fire()
    {
        if(isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinously());
        }
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinously()
    {
        while(true)
        {
            GameObject instance = Instantiate(projectilePrefab, 
                                            transform.position, 
                                            Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb !=null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }

            Destroy(instance, projectileLifetime);

            float timeToNextProjectile = Random.Range(baseFiringRate - fireRateVarience, 
                                                baseFiringRate + fireRateVarience);
            Mathf.Clamp(timeToNextProjectile, minimumFireRate, float.MaxValue);

            audioPlayer.PlayShootingClip();

            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }

    IEnumerator RapidFireCoroutine()
    {
        defaultVolume = audioPlayer.shootingVolume;
        audioPlayer.shootingVolume = 0.05f;
        baseFiringRate = rapidFirePickup;

        yield return new WaitForSeconds(rapidFireDuration);
        //decrease volume of shooting. Or change shooting clip
        

        baseFiringRate = defaultFiringRate;
        audioPlayer.shootingVolume = defaultVolume;
        isRapidFiring = false;
    }
}
