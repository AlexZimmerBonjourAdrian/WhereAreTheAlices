using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CLightSwitch : CGenericObject
{
    
    public bool IsActive = false;
    public bool IsComplete = false;
    public SpriteRenderer SpriteBackGround;
    public Sprite[] SpriteLight;

    private int pressed = 0;
    public void Awake()
    {
        SpriteBackGround = GetComponent<SpriteRenderer>();
        CPointToClick.Inst.CreatePoint();
        CGameEvents.OnLightSwitch.Subscribe(this.SwitchLight);
        CGameEvents.OnCounLightSwitch.Subscribe(this.CoutPressed); 
    }


    public void SwitchLight()
    {
        if(IsComplete == false)
        {

       
        if (IsActive)
        {
            SpriteBackGround.sprite = SpriteLight[0];
             IsActive = !IsActive;
        }
        else
        {
            SpriteBackGround.sprite = SpriteLight[1];
            IsActive = !IsActive;
        }

        }
    }

    public void ExtraTypes()
    {
        if(SpriteLight == null)
        {
            SpriteBackGround.sprite = SpriteLight[2];
        }
    }

    public void CompleteLight()
    {
        IsComplete = true;
        if (IsComplete == true)
        {
            SpriteBackGround.sprite = SpriteLight[3]; 
        }
    }

    public void ResetLight()
    {
        SpriteBackGround.sprite = SpriteLight[0];
        IsActive = false;
    }

    private void CoutPressed()
    {
        pressed +=1; 
        if(pressed >= 10)
        {
          
            Debug.Log(pressed);
              CompleteLight();
            CGameEvents.OnCompleteLevel.Publish(true);
            CGameEvents.OnActivateDoor.Publish();
            CLevelController.Inst.checkCompleteLevel();
        }
    }
}
