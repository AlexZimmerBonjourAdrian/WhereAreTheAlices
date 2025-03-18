using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using Subtegral.DialogueSystem.DataContainers;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UIElements.Button;


namespace Subtegral.DialogueSystem.Editor
{
    public class CStoryGraphView : GraphView
    {
        public readonly Vector2 DefaultNodeSize = new Vector2(200, 150);
        public CDialogueNode EntryPointNode;
        public Blackboard Blackboard = new Blackboard();
        public List<CExposedProperty> ExposedPropeties { get; private set; } = new List<CExposedProperty>();
    
        
    }


}
