using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDoorAlice : MonoBehaviour,Iinteract
{
      [SerializeField]
    private int idRoom;
    public void Oninteract()
    {
        // CManagerSFX.Inst.PlaySound(0);
        // CLevel0.Inst.SetRoomActive(idRoom, true);
    }
}
