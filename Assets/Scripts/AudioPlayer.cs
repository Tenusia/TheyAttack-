using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] public float shootingVolume = 1f;
    [SerializeField] AudioClip gunPoolShootingClip;
    [SerializeField] [Range(0f, 1f)] public float gunPoolVolume = 1f;
    
    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float damageVolume = 1f;
    [SerializeField] AudioClip forceField;
    [SerializeField] [Range(0f, 1f)] float shieldVolume = 1f;

    static AudioPlayer instance;
    AudioSource audioSource;

    void Awake()
    {
        ManageSingleton();
        audioSource = GetComponent<AudioSource>();
    }

    void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayGunPoolClip()
    {
        PlayClip(gunPoolShootingClip, gunPoolVolume);
    }

    public void PlayDamageClip()
    {
        PlayClip(damageClip, damageVolume);
    }
    public void ShieldClip()
    {
        PlayClip(forceField, shieldVolume);
    }

    public void TurnOffAudioSource()
    {
        audioSource.Stop();
    }

    public void TurnOnAudioSource()
    {
        if(audioSource != null)
        {
            audioSource.Play();
        }
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
