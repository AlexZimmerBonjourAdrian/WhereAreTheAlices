using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CClick : MonoBehaviour,Iinteract
{
   private SpriteRenderer _spriteRenderer;    

   private void Awake()
   {
      _spriteRenderer = GetComponent<SpriteRenderer>();
   }
    public void Oninteract()
    {
      
       // if(CLevelController.Inst.GetLevel() == 1)
       // {
          CManagerSFX.Inst.PlaySound(0);
          CGameEvents.OnLightSwitch.Publish(); 
          ChangeColor();
         CGameEvents.OnCounLightSwitch.Publish(); 
         
       // }
        
    }

    public void ChangeColor()
    {
        if(_spriteRenderer.color == Color.green)
        {
            _spriteRenderer.color = Color.red;
        }
        else
        {
            _spriteRenderer.color = Color.green;
        };
    }
    
}
