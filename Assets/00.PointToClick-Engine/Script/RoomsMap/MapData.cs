using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapData", menuName = "PointToClickEngine/MapData")]

[Serializable]
public class MapData : ScriptableObject
{    // Permite editar la estructura en el Inspector de Unity
  // ¡Añade [SerializeField] aquí!
    

   public List<StructRoom.Room> rooms;
   public Dictionary<int, StructRoom.Room> roomNodes = new Dictionary<int, StructRoom.Room>();
    
    public List<StructRoom.Room> GetRooms()
    {
        return rooms;
    }

}
