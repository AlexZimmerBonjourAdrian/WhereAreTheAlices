using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class CUiLoadingLevel : MonoBehaviour
{
   public float transitionTime = 1f;
   

   private enum StatetLoadign
   {
        FidIn,
        FadeOut,
   };
   // [SerializeField]public GameObject screenGameObject;

    [SerializeField] private CanvasGroup ControlGame;
    
  public void Awake()
    {
   
     DontDestroyOnLoad(this.gameObject);
        
    }
    void Start()
    {
        ControlGame = GetComponent<CanvasGroup>();

        
    }

    //public void StartLevel(int index)
    //{

    //  //  StartCoroutine(LoadLevelFadeIn(index));

    //}


 IEnumerator LoadLevelFadeIn()
  {
    // Fade in the CanvasGroup
      ControlGame.alpha = 0f; // Start at fully transparent
      while (ControlGame.alpha < 1f)
      {
          ControlGame.alpha += Time.deltaTime / transitionTime; // Gradually increase alpha
          yield return null; // Wait for the next frame
      }
      
       // CLevelManager.Inst.LoadScene(index);
        yield return new WaitForSeconds(transitionTime);         
  }

    IEnumerator LoadLevelFadeOut()
    {     
        // Fade out the CanvasGroup
        
        ControlGame.alpha = 1f; // Start at fully opaque
        while (ControlGame.alpha > 0f)
        {
           
            ControlGame.alpha -= Time.deltaTime / transitionTime; // Gradually decrease alpha
            yield return null; // Wait for the next frame
        }
  
        yield return new WaitForSeconds(transitionTime);
        
    }
    
}
   
