using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
     public GameObject MapUI; // Panel de la UI del mapa
     public GameObject RoomIconPrefab; // Prefab para los íconos de las habitaciones
 
     private RoomNode currentRoomNode; // Nodo de la habitación actual
     public Dictionary<int, RoomNode> roomNodes; // Diccionario para acceder a los nodos por ID
 
    
     // Inicializar el mapa y crear los nodos
     private void Start()
     {
         roomNodes = new Dictionary<int, RoomNode>();
         // ... (Lógica para crear los nodos de las habitaciones)
     }
 
     public void UpdateMap(int currentRoomId)
     {
         if (roomNodes.ContainsKey(currentRoomId))
         {
             currentRoomNode = roomNodes[currentRoomId];
             // Actualizar la visualización del mapa para indicar la habitación actual
             // ...
         }
         else
             throw new Exception("La habitación con ID " + currentRoomId + " no existe en el mapa.");
         // ...
     }
 
     public void OpenMap()
     {
         MapUI.SetActive(true);
     }
 
     public void CloseMap()
     {
         MapUI.SetActive(false);
     }
 }
 

