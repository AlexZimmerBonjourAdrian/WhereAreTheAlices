using UnityEngine;
using System;
using System.Collections.Generic;

using FloatDictionary = System.Collections.Generic.Dictionary<string, float>;
using StringDictionary = System.Collections.Generic.Dictionary<string, string>;
using BoolDictionary = System.Collections.Generic.Dictionary<string, bool>;
using PointClickerEngine;


public class CSaveSystem :  MonoBehaviour
{
    // main function used by Dialogue Runner to retrieve Yarn variable values
    
      void Start()
    {
        
        //Check Variable Type

        // Example 1: Check the type of a variable
        Type typeOfSanity = CManagerDialogue.Inst.GetDialogueRunner().VariableStorage.GetVariableType("$cordura");
        if (typeOfSanity != null)
        {
            Debug.Log($"Type of $cordura: {typeOfSanity.Name}");
        }
        else
        {
            Debug.Log("$cordura not found.");
        }
        
        Type typeOfPlayerName = CManagerDialogue.Inst.GetDialogueRunner().VariableStorage.GetVariableType("$playerName");
        if (typeOfPlayerName != null)
        {
            Debug.Log($"Type of $playerName: {typeOfPlayerName.Name}");
        }
        else
        {
            Debug.Log("$playerName not found.");
        }

        Type typeOfSacrifice= CManagerDialogue.Inst.GetDialogueRunner().VariableStorage.GetVariableType("$Sacrifice");
        if (typeOfSacrifice != null)
        {
            Debug.Log($"Type of $playerName: {typeOfSacrifice.Name}");
        }
        else
        {
            Debug.Log("$playerName not found.");
        }

        
        Type typeOfCruelty = CManagerDialogue.Inst.GetDialogueRunner().VariableStorage.GetVariableType("$Cruelty");
        if (typeOfCruelty != null)
        {
            Debug.Log($"Type of $Cruelty: {typeOfCruelty.Name}");
        }
        else
        {
            Debug.Log("$Cruelty not found.");
        }

    
        Type typeOfJustice  = CManagerDialogue.Inst.GetDialogueRunner().VariableStorage.GetVariableType("$Justice ");
        if (typeOfJustice != null)
        {
            Debug.Log($"Type of $Justice : {typeOfJustice.Name}");
        }
        else
        {
            Debug.Log("$Justice  not found.");
        }


    }
    // overload for setting a String variable

}
