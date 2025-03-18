using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAnimationController : MonoBehaviour
{


    #region Final Concept
    public Animator animator;

    private SpriteRenderer spriteRenderer;
    private int currentFrame = 2;


    #region  Debug-Region
    [SerializeField]private List<Sprite> animationFrames = new List<Sprite>();
    void Start()
        {
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>(); 
        }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayAnimation(); 
        }
 }
         public void PlayAnimation()
        {

            if (animationFrames.Count > 0) 
                
            {
                StartCoroutine(PlayAnimationCoroutine());
            } 
            else 
            {
                Debug.LogWarning("No hay frames en la animación.");
            }
         
        }
        
        private IEnumerator PlayAnimationCoroutine()
        {
            
            currentFrame = 0;

            while (currentFrame < animationFrames.Count)
            {
                spriteRenderer.sprite = animationFrames[currentFrame];
                currentFrame++;
                yield return new WaitForSeconds(0.1f); // Ajusta la velocidad de la animación aquí
            }
           
        }

          public void SetFrame(int frameIndex)
        {
            
                if (frameIndex >= 0 && frameIndex < animationFrames.Count)
                
                {
                    currentFrame = frameIndex;
                    spriteRenderer.sprite = animationFrames[currentFrame];
                }
                else
                {
                    Debug.LogWarning("Índice de frame fuera de rango.");
                }
            
        }
           #endregion
    }



    #endregion
   



