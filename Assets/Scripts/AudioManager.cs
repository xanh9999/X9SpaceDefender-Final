using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("ShootingSFX")]
    [SerializeField] AudioClip shootingSFX;
    [SerializeField] [Range(0f,1f)] float shootingSFXVolume = 1f;

    [Header("GotHitSFX")]
    [SerializeField] AudioClip gotHitSFX;
    [SerializeField] [Range(0f,1f)] float gotHitSFXVolume = 1f;   


    static AudioManager instance;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if(instance != null)
        {   
            gameObject.SetActive(false);
            Destroy(gameObject);
        }else
        {   
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingSFX()
    {
        PlayAudio(shootingSFX, shootingSFXVolume);
    }

    public void PlayGotHitSFX()
    {
        PlayAudio(gotHitSFX, gotHitSFXVolume);
    }

    void PlayAudio(AudioClip SFXclip, float volume)
    {
        if(SFXclip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(SFXclip, cameraPos, volume);
        }
    }



}
