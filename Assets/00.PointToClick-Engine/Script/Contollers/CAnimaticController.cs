using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Compiler;
using Yarn.Unity;
using Yarn.Unity.Example;
using UnityEngine.TextCore.Text;
using System;
using UnityEngine.UIElements;


namespace PointClickerEngine
{
[RequireComponent(typeof(SpriteRenderer))]
public class CAnimaticController : MonoBehaviour
{   
    
 public enum AnimaticState
{
    Playing,
    Paused,

    transition,
    Stopped
}

 [SerializeField]  private bool AutoPlay;

  private AnimaticState currentState = AnimaticState.Stopped;

  [SerializeField] private List<CAnimaticData> animaticData_List;

   private int currentAnimaticIndex = 0; // Índice de la animación actual
   [SerializeField] private SpriteRenderer ActualRenderer;

   [SerializeField] private SpriteRenderer NextRenderer;
    //Code to planning Manager Dialogs
    
    [SerializeField] private float fadeDuration = 1f; // Duration of the fade in/out

    private Coroutine currentFadeCoroutine;

    private CAnimaticData ActualAnimatic;

    
    [SerializeField] DialogueRunner runner;
    private void Start()
    {
        ActualRenderer = GetComponent<SpriteRenderer>();
        ActualRenderer.color = new Color(ActualRenderer.color.r, ActualRenderer.color.g, ActualRenderer.color.b, 0); // Empieza transparente

        runner.AddCommandHandler("PlayAnimaticCommand", PlayAnimatic);

        runner.AddCommandHandler("StopAnimaticCommand", StopAnimatic);

        runner.AddCommandHandler("PauseAnimaticCommand", PauseAnimatic);

        runner.AddCommandHandler<int>("PauseAnimaticCommand", ShowAnimatic);

        runner.AddCommandHandler("PlayNextAnimatic", PlayNextAnimatic);
        

        if(AutoPlay == true)
        {
            StartAnimatic();
        }
    }   
        

     void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                PlayNextAnimatic();
            }
        }

        // Inicia o continúa la reproducción de la animación


        public void PlayAnimatic()
        {
            if (currentState == AnimaticState.Stopped)
            {
                StartAnimatic();
            }
            else if (currentState == AnimaticState.Paused)
            {
                ResumeAnimatic();
            }
        }

        // Detiene completamente la animación y la reinicia
        public void StopAnimatic()
        {
            currentState = AnimaticState.Stopped;
            currentAnimaticIndex = 0;
            ActualRenderer.color = new Color(ActualRenderer.color.r, ActualRenderer.color.g, ActualRenderer.color.b, 0);
        }

        // Pausa la animación
        public void PauseAnimatic()
        {
            currentState = AnimaticState.Paused;
        }

        // Reproduce la siguiente animación en la lista
        public void PlayNextAnimatic()
        {
            
             currentAnimaticIndex++;
            
            if (currentAnimaticIndex < animaticData_List.Count)
            {
                ActualAnimatic = animaticData_List[currentAnimaticIndex];
                
                // Start the smooth transition to the next animatic
                currentFadeCoroutine = StartCoroutine(PlaySmoothTransitionToNextAnimatic());
            }
            else
            {
                // The animation has ended
                if (currentFadeCoroutine != null)
                {
                    StopCoroutine(currentFadeCoroutine);
                }
                
                currentFadeCoroutine = StartCoroutine(FadeOutAndQuit());
            }
        }
        
        

        // Método privado para mostrar una animación específica
        private void ShowAnimatic(int index)
        {
            if (index >= 0 && index < animaticData_List.Count)
            {
                ActualAnimatic = animaticData_List[index];
                ActualRenderer.sprite = ActualAnimatic.AnimationSprite;
                ActualRenderer.color = new Color(ActualRenderer.color.r, ActualRenderer.color.g, ActualRenderer.color.b, 1);
            }
            else
            {
                Debug.LogError("Índice de animación fuera de rango.");
            }
        }

        // Inicia la animación desde el principio
        private void StartAnimatic()
        {
            currentAnimaticIndex = 0;
            ShowAnimatic(currentAnimaticIndex);
            currentState = AnimaticState.Playing;
        }

        // Continúa la animación desde donde se pausó
        private void ResumeAnimatic()
        {
            currentState = AnimaticState.Playing;
        }

  
   
        
    

        private IEnumerator TransitionToAnimatic(int index)
        {
            yield return FadeOut(fadeDuration);
            ShowAnimatic(index);  // Now separated from fade logic
            yield return FadeIn(fadeDuration);
        }

        private IEnumerator FadeOutAndQuit()
        {
            yield return FadeOut(fadeDuration);

            ActualRenderer.color = new Color(ActualRenderer.color.r, ActualRenderer.color.g, ActualRenderer.color.b, 0f); // Ensure fully transparent
            CGameEvents.OnGameplayStart?.Publish();
        }

        


      private IEnumerator FadeOut(float duration)
        {
            float elapsedTime = 0f;
            Color startColor = ActualRenderer.color;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float alpha = Mathf.Lerp(1f, 0f, elapsedTime / duration);
                ActualRenderer.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
                yield return null;
            }

            ActualRenderer.color = new Color(startColor.r, startColor.g, startColor.b, 0f); // Ensure fully transparent
        }

        private IEnumerator FadeIn(float duration)
        {
            float elapsedTime = 0f;
            Color startColor = ActualRenderer.color;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float alpha = Mathf.Lerp(0f, 1f, elapsedTime / duration);
                ActualRenderer.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
                yield return null;
            }

            ActualRenderer.color = new Color(startColor.r, startColor.g, startColor.b, 1f); // Ensure fully opaque
        }
    
     private IEnumerator PlaySmoothTransitionToNextAnimatic()
        {
            if (currentFadeCoroutine != null)
            {
                StopCoroutine(currentFadeCoroutine);
            }
            
            float elapsedTime = 0f;
            Sprite startSprite = ActualRenderer.sprite;
            Sprite endSprite = ActualAnimatic.NextAnimation.AnimationSprite; // Assuming _NextAnimatic is the next animatic in your list
            
            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                
                float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration); // This will create a smooth transition
                ActualRenderer.color = new Color(ActualRenderer.color.r, ActualRenderer.color.g, ActualRenderer.color.b, alpha);
                
                ActualRenderer.sprite = alpha < 0.5f ? startSprite : endSprite; // Simple switch between sprites based on alpha
                
                yield return null;
            }
        }
      private void OnEnable()
    {
       // StartAnimatic();

       CGameEvents.OnAnimaticPlay.Subscribe(PlayAnimatic);
       CGameEvents.OnAnimaticStop.Subscribe(StopAnimatic);
       CGameEvents.OnAnimaticNext.Subscribe(PlayNextAnimatic);
       


    }
    private void OnDisable()
    {
        CGameEvents.OnAnimaticPlay.Unsubscribe(PlayAnimatic);
       CGameEvents.OnAnimaticStop.Unsubscribe(StopAnimatic);
       CGameEvents.OnAnimaticNext.Unsubscribe(PlayNextAnimatic);
      
    }

    

}

}
   
