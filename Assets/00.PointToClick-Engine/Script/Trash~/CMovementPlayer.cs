using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMovementPlayer : MonoBehaviour, Iinteract
{
      [SerializeField] private int id_room;

      public void Awake()
    {
        CPointToClick.Inst.CreatePoint();
        //CGameEvent.current.OnMove += FunctionMove;
    }
  
   public void MoveLocation(int id)
   {
     // CLevel2.Inst.LoadRoom(id);  
     CLevel2.Inst.SetRoomActive(id,true);
   }

    public void Oninteract()
    {
      FunctionMove();
    }

    private void FunctionMove()
    {
       MoveLocation(id_room);
    }

    
}
