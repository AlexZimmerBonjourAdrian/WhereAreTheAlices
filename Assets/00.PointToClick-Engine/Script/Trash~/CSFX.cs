using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSFX : MonoBehaviour
{
    [SerializeField] private AudioClip sound;

   [SerializeField]   private AudioSource audioSource;

     [SerializeField] private ESFXType.SFXType SFXType;
    
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlaySFX()
    {
        audioSource.clip = sound;
        audioSource.Play();
    }

    public void StopSFX()
    {
        audioSource.Stop();
    }

    public void DestroySFX()
    {
        Destroy(gameObject);
    }

    public void SetLoopSound(bool loop)
    {
        audioSource.loop = loop;
    }


    public ESFXType.SFXType GetSFXType()
    {
        return SFXType;
    }

    public AudioClip GetAudioClip()
    {
        return this.sound;
    }
}
