using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using Subtegral.DialogueSystem.DataContainers;
using UnityEditor;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MapGraphView //: GraphView
{
    // // Start is called before the first frame update
    //  public readonly Vector2 DefaultNodeSize = new Vector2(200, 150);
    
    // public readonly Vector2 DefaultCommentBlockSize = new Vector2(300, 200);

    //     public RoomNode EntryPointNode;
    //     public Blackboard Blackboard = new Blackboard();
    //     public List<ExposedProperties> ExposedPropeties { get; private set; } = new List<ExposedProperties>();
        
    //     //private NodeSearchWindow _searchWindow;
    //     private Texture2D DefaultSprite;
    //      void Start()
    //     {
    //         DefaultSprite = Resources.Load<Texture2D>("Prefab / DefaultSprite");
    //     }
    //      public MapGraphView(MapGraph editorWindow)
    //     {
    //          styleSheets.Add(Resources.Load<StyleSheet>("NarrativeGraph"));
    //          SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);


    //         // this.AddManipulator(new ContentDragger());
    //         // this.AddManipulator(new SelectionDragger());
    //         // this.AddManipulator(new RectangleSelector());
    //         // this.AddManipulator(new FreehandSelector());

    //          var grid = new GridBackground();
    //          Insert(0, grid);
    //          grid.StretchToParentSize();

    //         // AddElement(GetEntryPointNodeInstance());

    //         // AddSearchWindow(editorWindow);
    //     }

    //     public void ClearBlackBoardAndExposedProperties()
    //     {
    //         ExposedPropeties.Clear();
    //         Blackboard.Clear();
    //     }

    //     public Group CreateCommentBlock(Rect rect, CommentBlockDataRoom commentBlockData = null )
    //     {
    //        if(commentBlockData==null)
    //             commentBlockData = new CommentBlockDataRoom();
    //         var group = new Group
    //         {
    //             autoUpdateGeometry = true,
    //             title = commentBlockData.Title
    //         };
    //         AddElement(group);
    //         group.SetPosition(rect);
    //         return group;
    //     }  
        
    //  public void AddPropertyToBlackBoard(ExposedProperties property, bool loadMode = false)
    //  {
    //     var localPropertyName = property.PropertyName;
    //     var localPropertyValue = property.PropertyValue;

    //     var localPropertyNameCharacter = property.PropertyNameCharacter;
    //     if (!loadMode)
    //     {
    //       while (ExposedPropeties.Any(x => x.PropertyName == localPropertyName))
    //            localPropertyName = $"{localPropertyName}(1)";
    //     }
    //        var item = ExposedProperties.CreateInstance();
    //         item.PropertyName = localPropertyName;
    //         item.PropertyValue = localPropertyValue;
    //         item.PropertyNameCharacter = localPropertyNameCharacter;
    //        // item.PropertySprite = localPropertySprite;
    //         ExposedPropeties.Add(item);

    //          var container = new VisualElement();
    //         //Serch Elements in BlackBoard
    //         var field = new BlackboardField {text = localPropertyName, typeText = "string"};
    //         container.Add(field);

    //         var propertyValueTextField = new TextField("Value:")
    //         {
    //             value = localPropertyValue
                
    //         };
    //         propertyValueTextField.RegisterValueChangedCallback(evt =>
    //         {
    //             var index = ExposedPropeties.FindIndex(x => x.PropertyName == item.PropertyName);
    //             ExposedPropeties[index].PropertyValue = evt.newValue;
    //         });
    //         var sa = new BlackboardRow(field, propertyValueTextField);
    //         container.Add(sa);
    //         Blackboard.Add(container);
    //  }
    //      public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
    //     {
    //         var compatiblePorts = new List<Port>();
    //         var startPortView = startPort;

    //         ports.ForEach((port) =>
    //         {
    //             var portView = port;
    //             if (startPortView != portView && startPortView.node != portView.node)
    //                 compatiblePorts.Add(port);
    //         });

    //         return compatiblePorts;
    //     }

    //   public void CreateNewDialogueNode(string nodeName, Vector2 position, Texture2D Sprite, string nameRoom,bool IsEntryPoint, bool IsEndRoom,GameObject InteractsObject, List<RoomNode> ConnectedRoomList)
    // {
    //     AddElement(CreateNode(nodeName, position,Sprite,nameRoom,IsEntryPoint, IsEndRoom,  InteractsObject, ConnectedRoomList));
    // }

    //  public RoomNode CreateNode(string nodeName, Vector2 position, Texture2D Sprite, string nameRoom,bool IsEntryPoint, bool IsEndRoom,GameObject InteractsObject, List<RoomNode> ConnectedRoomList )
    //     {
    //         var tempRoomNode = new RoomNode()
    //         {
    //             title = nodeName,
    //             RoomName = nodeName,
    //            // SpriteCharacter = Sprite,
    //             // NameCharacter = nameCharacter,
    //             // SpriteCharacter = Sprite,
    //             EntryPoint = IsEntryPoint,
    //             EndRoom = IsEndRoom,
    //             Interacts = InteractsObject,
    //             ConnectedRooms = ConnectedRoomList,
               
    //             GUID = Guid.NewGuid().ToString()
               
    //         };
    //         tempRoomNode.styleSheets.Add(Resources.Load<StyleSheet>("Node"));
    //         var inputPort = GetPortInstance(tempRoomNode, Direction.Input, Port.Capacity.Multi);
    //         inputPort.portName = "Input";
    //         tempRoomNode.inputContainer.Add(inputPort);
    //         tempRoomNode.RefreshExpandedState();
    //         tempRoomNode.RefreshPorts();
    //         tempRoomNode.SetPosition(new Rect(position,
    //             DefaultNodeSize)); //To-Do: implement screen center instantiation positioning

    //         var textField = new TextField("");
    //         var textFieldCharacter = new TextField("");
    //         var textFieldNumberRoom = new TextField("");
    //         var check = new UnityEngine.UIElements.Toggle();
    //         var SpriteCharacter =  DefaultSprite;
    //        // var SpriteCharacterDefault = DefaultSprite;
    //         textField.RegisterValueChangedCallback(evt =>
    //         {
           
    //            tempRoomNode.title = evt.newValue;
    //             // tempDialogueNode.NameCharacter = evt.newValue;
    //             //tempDialogueNode.NameCharacter = evt.newValue;
    //            tempRoomNode.RoomName= evt.newValue;

                

    //         });

    //         //  textFieldNumberRoom.RegisterValueChangedCallback(evt =>
    //         // {
           
    //         //      tempRoomNode.RoomId = evt.newValue;

                

    //         // });
    //         // textFieldCharacter.RegisterValueChangedCallback(evt =>
    //         // { 
    //         //     tempRoomNode.NameCharacter = evt.newValue; 
    //         // });

            
    //         /*
    //         textFieldCharacter.RegisterValueChangedCallback(evt =>
    //         {
               
    //         });
    //         */


    //     //     textFieldCharacter.SetValueWithoutNotify(tempDialogueNode.NameCharacter);
    //     //     textField.SetValueWithoutNotify(tempDialogueNode.title);
    //     //    // SpriteCharacterDefault = tempDialogueNode.SpriteCharacter;
          
    //     //     tempDialogueNode.mainContainer.Add(textField);
    //     //     tempDialogueNode.mainContainer.Add(textFieldCharacter);

    //     //     var button = new Button(() => { AddChoicePort(tempDialogueNode); })
    //     //     {
    //     //         text = "Add Choice"
    //     //     };
    //     //     //TODO: load sprinte in editor
    //     //     //OR
    //     //     //Load image using Events
    //     //     //var Sprite = new Image(() = >{ Addimage(Image) ;)
            
    //     //     tempDialogueNode.titleButtonContainer.Add(button);
    //     //     return tempDialogueNode;
    //     }

        //  private Port GetPortInstance(RoomNode node, Direction nodeDirection,
        //     Port.Capacity capacity = Port.Capacity.Single)
        // {
        //     return node.InstantiatePort(Orientation.Horizontal, nodeDirection, capacity, typeof(float));
        // }

        // private RoomNode GetEntryPointNodeInstance()
        // {
        //     var nodeCache = new  RoomNode()
        //     {
        //         title = "START",
        //         GUID = Guid.NewGuid().ToString(),
        //         ConnectedRooms = new List<RoomNode>(),
        //         Interacts = null,
        //         EntryPoint = false,
        //         EndRoom= true
        //     };
        //     var generatedPort = GetPortInstance(nodeCache, Direction.Output);
        //     generatedPort.portName = "Next";
        //     nodeCache.outputContainer.Add(generatedPort);

        //     nodeCache.capabilities &= ~Capabilities.Movable;
        //     nodeCache.capabilities &= ~Capabilities.Deletable;

        //     nodeCache.RefreshExpandedState();
        //     nodeCache.RefreshPorts();
        //     nodeCache.SetPosition(new Rect(100, 200, 100, 150));
        //     return nodeCache;

        // }
}
