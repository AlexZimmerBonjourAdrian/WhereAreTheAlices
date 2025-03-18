using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StructRoom 
{
    // Static list to store Room structs
    public static List<Room> rooms = new List<Room>();

    // Nested struct to represent a room
    [Serializable] // Asegúrate de que la estructura Room también sea serializable
    [SerializeField] 
    public struct Room
    {
        public int id;
        public Sprite RoomImage;
        public bool IsAccessible;
        public string tag;

        public void SetIsAccessible(bool v)
        {
            IsAccessible = v;
        }
    }
}
