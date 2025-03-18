using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{  
   [SerializeField]
   private int IdRoom;

   private string RoomName;

   private void Awake()
   {
      RoomName = gameObject.name;
   } 
}
