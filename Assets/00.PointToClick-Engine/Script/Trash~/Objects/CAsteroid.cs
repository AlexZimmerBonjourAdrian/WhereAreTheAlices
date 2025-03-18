using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAsteroid : MonoBehaviour, Iinteract
{
    [SerializeField]
    private SpriteRenderer spriterender;
    private Color ColorNormal = Color.white;
    Color ColorAlterate = new Color(232, 255, 0, 255);
    private bool bul = false;
    void Awake()
    {
        spriterender = GetComponent<SpriteRenderer>();
    }
    /*
    void start()
    {
        spriterender = GetComponent<SpriteRenderer>();
    }
    */
    public void Oninteract()
    {
        Debug.Log("Hola");
        ChangeColor();
    }


    private void ChangeColor()
    {

        switch(bul)
        {
            case false:
                spriterender.color = ColorNormal;
                break;
            case true:
                spriterender.color = ColorAlterate;
                break;
            
        }

        bul = !bul;
        
    }

}
