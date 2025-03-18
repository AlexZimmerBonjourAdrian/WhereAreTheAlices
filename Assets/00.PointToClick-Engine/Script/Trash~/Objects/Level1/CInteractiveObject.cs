using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInteractiveObject : MonoBehaviour,Iinteract
{
    public int id;
    public void Awake()
    {
        CPointToClick.Inst.CreatePoint();
        //CGameEvent.current.OnChangeColor += Selected;
    }

    public void Oninteract()
    {
        Selected(id);
    }

      public void Selected(int id)
    {
        // Reproducir sonido de seleccion
       CManagerSFX.Inst.PlaySound(0);
        CLevel1.Inst.CheckSuccesfull(id);
    }

    public void Deselected()
    {
        // Reproducir sonido de deseleccion
       CManagerSFX.Inst.PlaySFX(ESFXType.SFXType.Unselected);
    }

    public void Complete()
    {
        // Solo reproduccirlo una sola vez
        // Reproducir sonido de Completado
        CManagerSFX.Inst.PlaySFX(ESFXType.SFXType.Door);
    }
}
