using System;
using System.Collections.Generic;
using UnityEngine;

public class RoomContainer : ScriptableObject
{
    // Start is called before the first frame update
   public List<NodeLinkRoom> NodeLinks = new List<NodeLinkRoom>();
        public List<RoomNode> DialogueNodeData = new List<RoomNode>();
        public List<ExposedProperties> ExposedProperties = new List<ExposedProperties>();
        public List<CommentBlockDataRoom> CommentBlockData = new List<CommentBlockDataRoom>();
}
