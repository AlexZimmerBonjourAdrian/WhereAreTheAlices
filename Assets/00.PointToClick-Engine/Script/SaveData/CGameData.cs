using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CGameData 
{
 
    public List<string> dialogueHistory;
    public HashSet<string> executedDialogues;

    // Variables de Control
    public string currentYarnProjectName;
    public Dictionary<string, float> floatVariables;
    public Dictionary<string, string> stringVariables;
    public Dictionary<string, bool> boolVariables;

}
