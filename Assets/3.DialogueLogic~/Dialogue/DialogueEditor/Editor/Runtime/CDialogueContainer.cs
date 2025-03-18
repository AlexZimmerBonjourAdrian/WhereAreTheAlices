using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class CDialogueContainer : ScriptableObject
{

    public List<CNodeLinkData> NodeLinks = new List<CNodeLinkData>();
    public List<CDialogueNodeData> DialogueNodeData = new List<CDialogueNodeData>();
    public List<CExposedProperty> ExposedProperties = new List<CExposedProperty>();

    
}
