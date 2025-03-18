using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PointClickerEngine;

public class CDoor : MonoBehaviour, Iinteract
{
    [SerializeField]
    private int IndexLevel = 0;
    [SerializeField]
    private bool ThisLevelIsComplete = false;
    private SpriteRenderer SpriteRender;   

    private void Awake()
    {
        CPointToClick.Inst.CreatePoint(); 
        CGameEvents.OnActivateDoor.Subscribe(this.ViewDoor);
        CGameEvents.OnCompleteLevel.Subscribe(SetThisLevelIsComplete);
        
    }
    void Start()
    {
        SpriteRender = GetComponent<SpriteRenderer>();
    }
    public void Oninteract()
    {
        Debug.Log(ThisLevelIsComplete);
        if(ThisLevelIsComplete == true)
        {
         if(IndexLevel> 0)
           {
             CLevelManager.Inst.LoadScene(IndexLevel);
           }
            else 
            CLevelManager.Inst.LoadNextScene();
        }
        
        else
        {
            Debug.LogError("El nivel no esta completo");
        }
    }
    

    public void SetRoom(int idex)
    {
         IndexLevel = idex;
    }
    public void SetThisLevelIsComplete(bool isBool)
    {
        ThisLevelIsComplete = isBool;
    }

    public void ViewDoor()
    {
        SpriteRender.color = new Color(255f, 255f, 255f, 255f);
    }
}
