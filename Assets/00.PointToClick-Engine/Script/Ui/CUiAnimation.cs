using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;
 
 [RequireComponent(typeof(Image))]

public class CUiAnimation : MonoBehaviour
{
    [SerializeField]
    private EAnimationStates.StetesAnimationUI AStates;

    public float duration;

    [SerializeField] private Sprite[] sprites;
  // [SerializeField] public List<List<Sprite>> _lista;
      
    [SerializeField] private Image image;
   // [SerializeField] public Sprite[][] SpritesArray ;
    private int index = 0;
    private float timer = 0;

    void Start()
    {
        image = GetComponent<Image>();
    }
    private void Update()
    {
        if(AStates == EAnimationStates.StetesAnimationUI.Loading) {
            if ((timer += Time.deltaTime) >= (duration / sprites.Length))
            {
                timer = 0;
                image.sprite = sprites[index];
                index = (index + 1) % sprites.Length;
            }
        }

        else if(AStates == EAnimationStates.StetesAnimationUI.Characters)
        {
            Debug.Log("Implementar codigo, characters");
        }
    }
}
