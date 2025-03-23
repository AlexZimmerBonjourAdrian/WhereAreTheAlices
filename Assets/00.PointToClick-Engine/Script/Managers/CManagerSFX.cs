using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Yarn.Unity;
using PointClickerEngine;
public class CManagerSFX : MonoBehaviour
{   
    public static CManagerSFX Inst
    {
        get
        {
            if (_inst == null)
            {
                _inst = FindFirstObjectByType<CManagerSFX>();
                if (_inst == null)
                {
                    GameObject obj = new GameObject("ManagerSFX");
                    _inst = obj.AddComponent<CManagerSFX>();
                }
            }
            return _inst;
        }
    }

     
   

    private static CManagerSFX _inst;

	[SerializeField] DialogueRunner runner;

    public void Awake()
    {
    if(_inst != null && _inst != this)
        {
            Destroy(gameObject);
            return;
        }
      //  DontDestroyOnLoad(this.gameObject);
        _inst = this;

        runner = CManagerDialogue.Inst.GetDialogueRunner();
        runner.AddCommandHandler<int>("PlaySFX", PlaySound); // Added command handler
        runner.AddCommandHandler("StopSFX", StopSFX); // Added command handler
    }

public void Start()
{
    CGameEvents.OnPlaySound.Subscribe(PlaySound);
}
    
    [SerializeField] public List<AudioClip> ListSFX;
    [SerializeField] public AudioMixer audioMixer;

    private List<GameObject> ListSounds;

    [SerializeField]public Dictionary<AudioClip, string> soundMap = new Dictionary<AudioClip, string>();

    public void AddSound()
    {
    GameObject soundObject = new GameObject("Sound");
    soundObject.AddComponent<AudioSource>();
    ListSounds.Add(soundObject);
    }
  
      public void PlaySFX(ESFXType.SFXType type)
    {
        // Buscar el AudioClip correspondiente al tipo de SFX
        AudioClip clip = ListSFX.Find(c => c.name == type.ToString());
        if (clip != null)
        {
            // Crear un nuevo objeto de sonido y reproducirlo
            GameObject soundObject = new GameObject("Sound");
          //  soundObject.AddComponent<CSFX>();
            soundObject.AddComponent<AudioSource>().clip = clip;
            soundObject.AddComponent<AudioSource>().Play();
            ListSounds.Add(soundObject);
        }
    }

public void PlaySound(int id)
{
    // Buscar el AudioClip correspondiente al id
    AudioClip clip = ListSFX[id];
    AudioSource soundObject = GetComponent<AudioSource>();
    soundObject.clip = clip;
    soundObject.Play();

}
public void StopSFX()
{
    foreach (GameObject sound in ListSounds)
    {
        sound.GetComponent<AudioSource>().Stop();
        
    }
}

}
