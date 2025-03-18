using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CChangeForms : MonoBehaviour,Iinteract
{
    
    [Range(0,5)]
    [SerializeField]private int value;

    [Range(0,3)]
    [SerializeField]private int position;

    
    // Start is called before the first frame update
    public void Oninteract()
    {
        if(CLevelController.Inst.GetLevel()==0)
        {
            if(value <= 5)
            {
                value += 1;
            }
            else
            {
                value = 0;
            }
          //  CLevel0.Inst.MoficiationSequencePuzzle(position,value);
        }
    }
        
}
