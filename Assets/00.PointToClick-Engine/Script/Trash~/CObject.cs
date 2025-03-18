using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CObject : CGenericObject, Iinteract
{
    //Example Object
    [SerializeField]
    private string Texto= " ";
   public void Oninteract()
    {
        Debug.Log(Texto);
    }
}
