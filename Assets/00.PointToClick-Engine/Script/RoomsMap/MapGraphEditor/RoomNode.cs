using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.Experimental.GraphView;
public class RoomNode //:  Node
{
      public int RoomId;
      
      public string RoomName;
      
      public string GUID;

      public GameObject Interacts;
      public List<RoomNode> ConnectedRooms;
      
    public bool EntryPoint = false;

    public bool EndRoom = false;

    
  }
  

