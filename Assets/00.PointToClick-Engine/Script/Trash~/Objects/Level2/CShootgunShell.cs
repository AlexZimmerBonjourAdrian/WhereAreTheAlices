using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CShootgunShell : MonoBehaviour, Iinteract
{
    // Start is called before the first frame update

    [SerializeField]
    private int idRoom;
    public void Oninteract()
    {
        CManagerSFX.Inst.PlaySound(0);
        CLevel2.Inst.SetIsShootGunShell(true);
        CLevel2.Inst.SetRoomActive(idRoom, true);
    }
}