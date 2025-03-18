using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
//using Subtegral.DialogueSystem

namespace Subtegral.DialogueSystem.Editor
{ 
public class CStoryGraph : EditorWindow
{
        private string _fileName = "New Narrative";

        private List<CNode> nodes;

        private GUIStyle nodeStyle;

        private CDialogueContainer _dialogueContainer;

        private CStoryGraphView _graphview;
        //private CDialogueContainer _dialogueContainer;

        [MenuItem("Graph/Narrative Graph")]
        public static void CreateGraphviewWindow()
        {
            var window = GetWindow<CStoryGraph>();
            window.titleContent = new GUIContent("Narrative Graph");
        }


        private void OnEnable()
        {
            nodeStyle = new GUIStyle();
            nodeStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/node1.png") as Texture2D;
            nodeStyle.border = new RectOffset(12, 12, 12, 12);
        }

        private void OnGUI()
        {
            DrawNodes();

            ProcessNodeEvents(Event.current);
            ProcessEvents(Event.current);

            if (GUI.changed) Repaint();
        }

        private void DrawNodes()
        {
            if (nodes != null)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    nodes[i].Draw();
                }
            }
        }
        private void ProcessEvents(Event e)
        {
            switch (e.type)
            {
                case EventType.MouseDown:
                    if (e.button == 1)
                    {
                        ProcessContextMenu(e.mousePosition);
                    }
                    break;
            }
        }

        private void ProcessContextMenu(Vector2 mousePosition)
        {
            GenericMenu genericMenu = new GenericMenu();
            genericMenu.AddItem(new GUIContent("Add node"), false, () => OnClickAddNode(mousePosition));
            genericMenu.ShowAsContext();
        }

        private void OnClickAddNode(Vector2 mousePosition)
        {
            if (nodes == null)
            {
                nodes = new List<CNode>();
            }

            nodes.Add(new CNode(mousePosition, 200, 50, nodeStyle));
        }

        private void ProcessNodeEvents(Event e)
        {
            if (nodes != null)
            {
                for (int i = nodes.Count - 1; i >= 0; i--)
                {
                    bool guiChanged = nodes[i].ProcessEvents(e);

                    if (guiChanged)
                    {
                        GUI.changed = true;
                    }
                }
            }
        }
    }
    /*
    private void ContractGraphView()
    {

    }
    */
    /*
    private void GenerateBlackBoard()
    {
        var blackboard = new Blackboard()
    }
    */
    /*
    private void GenerateBlackBoard()
    {
        Debug.Log("Entra");
        var blackboard = new Blackboard(_graphview);
        blackboard.Add(new BlackboardSection { title = "Exposed variable" });
        /*  blackboard.addItemRequested = _blackboard=>
          {
              _graphview.
          }


        blackboard.SetPosition(new Rect(10, 30, 200, 300));
        _graphview.Add(blackboard);
        _graphview.Blackboard = blackboard;
    }
*/
    /*
    private void OnDisable()
    {
        rootVisualElement.Remove(_graphview);
    }
    */

}
