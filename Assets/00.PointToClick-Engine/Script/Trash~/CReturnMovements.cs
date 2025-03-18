using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CReturnMovements : MonoBehaviour, Iinteract
{
   [SerializeField]
   private int id;
   public void Oninteract()
   {
      if(!CLevel2.Inst.GetIsFinishLevel())
      {
         Povregion();
         MesaRegion();
         id = 0;
         CLevel2.Inst.SetRoomActive(id,true);     
      }
      else
      {
         id = 11;
         CLevel2.Inst.SetRoomActive(id,true);   
      }
      
       CManagerSFX.Inst.PlaySFX(0);
   }

   private void Povregion()
   {
      if(CLevel2.Inst.GetIsRevolver() == true && (CLevel2.Inst.GetIsShootGunShell() == false) && (CLevel2.Inst.GetIsShootMusicBox() == false) )
      {
         CLevel2.Inst.SetPovActive(1,true);
      }

      else if((CLevel2.Inst.GetIsShootGunShell() == true) && (CLevel2.Inst.GetIsRevolver() == true) && (CLevel2.Inst.GetIsShootMusicBox() == false)) 
      {
         CLevel2.Inst.SetPovActive(2,true);
      }

      else if( (CLevel2.Inst.GetIsShootGunShell() == true) && (CLevel2.Inst.GetIsRevolver() == true) && (CLevel2.Inst.GetIsShootMusicBox() == true))
      {   
         CLevel2.Inst.SetPovActive(3,true);
      }
      // else if(CLevel2.Inst.GetIsShootMusicBox() == true)
      // {
      //    CLevel2.Inst.SetPovActive(4,true);
      // }
      else
      {
         CLevel2.Inst.SetPovActive(0,true);
      }
   }


   private void MesaRegion()
   {
      if((CLevel2.Inst.GetIsTakeShootGun() == true ) && (CLevel2.Inst.GetIsMagRevolver() == false ))
      {
         CLevel2.Inst.SetMesaActive(1,true);
      }

      else if((CLevel2.Inst.GetIsTakeShootGun() == false) && (CLevel2.Inst.GetIsMagRevolver() == true))
      {       
          CLevel2.Inst.SetMesaActive(2,true);
        
      }
       else if((CLevel2.Inst.GetIsTakeShootGun() == true) && (CLevel2.Inst.GetIsMagRevolver() == true))
      {       
          CLevel2.Inst.SetMesaActive(3,true);
        
      }
       else
      {       
          CLevel2.Inst.SetMesaActive(0,true);   
      }
   }

}
   
