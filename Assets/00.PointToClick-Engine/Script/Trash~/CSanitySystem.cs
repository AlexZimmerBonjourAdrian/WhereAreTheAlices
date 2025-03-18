using PointClickerEngine;
using UnityEngine;
using Yarn.Unity;
public class CSanitySystem : MonoBehaviour
{
   [Header("Sanity Settings")]  
    public int maxSanity = 100;  
    public AudioClip heartbeatSound;  

    private AudioSource audioSource;  
   // private PostProcessingController postFX;  

    void Start() {  
        audioSource = GetComponent<AudioSource>();  
      //  postFX = Camera.main.GetComponent<PostProcessingController>();  
    }  

    // Llamado desde Yarn Command <<modificar_cordura -20>>  
    [YarnCommand("modificar_cordura")]  
    public void UpdateSanity(int amount) {  
       // int newSanity = Mathf.Clamp(CManagerDialogue.Inst.GetDialogueRunner().VariableStorage.Get("$cordura").AsNumber + amount, 0, 100);  
       // DialogueRunner.Instance.VariableStorage.SetValue("$cordura", newSanity);  

        // Efectos  
       // postFX.SetVignetteIntensity(1 - (newSanity / 100f));  
        //audioSource.pitch = 1 + ((100 - newSanity) * 0.02f);  
       // if (newSanity <= 30) audioSource.PlayOneShot(heartbeatSound);  
    }  
}
