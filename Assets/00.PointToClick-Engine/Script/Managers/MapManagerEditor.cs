using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
//using UnityEditor.Experimental.GraphView;

public class MapManagerEditor //: EditorWindow
 {
//     private MapManager mapManager;
//     private MapData mapData;

//     private Dictionary<RoomNode, Rect> nodeRects = new Dictionary<RoomNode, Rect>();
//     private RoomNode selectedNode;
//     private bool connectingNodes;

//     private Vector2 gridSize = new Vector2(20f, 20f);
//     //generate roomNodes 
//     private Dictionary<int, RoomNode> roomNodes;
//     private Vector2 scrollPosition;

//     [MenuItem("PointToClickEngine/Map Manager")]
//     public static void ShowWindow()
//     {
//         GetWindow<MapManagerEditor>("Map Manager");
//     }

//     private void OnGUI()
//     {
//         // Buscar la instancia de MapManager en la escena
//         if (mapManager == null)
//         {
//             mapManager = FindObjectOfType<MapManager>();
//         }

//         if (mapManager == null)
//         {
//             EditorGUILayout.HelpBox("No se encontró una instancia de MapManager en la escena.", MessageType.Warning);
//             return;
//         }
        
//         // Cargar o crear ScriptableObject
//         if (mapData == null)
//         {
//            // LoadMapData();
//         }

        
//         // Mostrar la información del mapa
//         EditorGUILayout.LabelField("Mapa del juego", EditorStyles.boldLabel);

//         // Botones para crear habitaciones y guardar el mapa
//         EditorGUILayout.BeginHorizontal();
//         // if (GUILayout.Button("Crear Habitación"))
//         // {
//         //     CreateRoomNode();
//         // }
//         if (GUILayout.Button("Guardar Mapa"))
//         {
//           //  SaveMapData();
//         }
//         EditorGUILayout.EndHorizontal();
//          EditorGUILayout.BeginVertical(GUILayout.ExpandHeight(true));
//         scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
      
        
        
    
//          DrawGrid();
//         // Dibujar conexiones entre nodos
//         DrawConnections();

//         // Dibujar nodos
//         DrawNodes();

       
//         EditorGUILayout.EndScrollView();
//         EditorGUILayout.EndVertical();

//         // Manejar eventos del mouse
//         ProcessEvents(Event.current);

//         // Actualizar la ventana del editor
//         if (GUI.changed)
//         {
//             Repaint();
//         }


//     }

//     // private void LoadMapData()
//     // {
//     //     string path = EditorUtility.OpenFilePanel("Cargar datos del mapa", "Assets", "asset");
//     //     if (path.StartsWith(Application.dataPath))
//     //     {
//     //         path = "Assets" + path.Substring(Application.dataPath.Length);
//     //     }

//     //     mapData = AssetDatabase.LoadAssetAtPath<MapData>(path);
//     //     if (mapData != null)
//     //     {
//     //         roomNodes = mapData.roomNodes;
//     //     }
//     //     else
//     //     {
//     //         mapData = CreateInstance<MapData>();
//     //         roomNodes = new Dictionary<int, RoomNode>();
//     //     }
//     // }

//     // private void SaveMapData()
//     // {
//     //     if (mapData == null)
//     //     {
//     //         mapData = CreateInstance<MapData>();
//     //     }

//     //     mapData.roomNodes = roomNodes;

//     //     string path = EditorUtility.SaveFilePanelInProject("Guardar datos del mapa", "MapData", "asset", "Guardar mapa como...");
//     //     if (!string.IsNullOrEmpty(path))
//     //     {
//     //         AssetDatabase.CreateAsset(mapData, path);
//     //         AssetDatabase.SaveAssets();
//     //     }
//     // }

//     // private void CreateRoomNode()
//     // {
//     //     RoomNode newNode = new RoomNode(roomNodes.Count);
//     //     roomNodes.Add(newNode.RoomId, newNode);
//     //     nodeRects.Add(newNode, new Rect(position.width / 2 - 50, position.height / 2 - 25, 100, 50));
//     // }

//    private void DrawNodes()
//     {
//         BeginWindows();
//         foreach (var kvp in roomNodes)
//         {
//             RoomNode node = kvp.Value;
//             Rect rect = nodeRects.ContainsKey(node) ? nodeRects[node] : new Rect(Vector2.zero, Vector2.one * 100);

//             // Mover el nodo con el mouse
//             if (Event.current.type == EventType.MouseDrag && rect.Contains(Event.current.mousePosition))
//             {
//                 nodeRects[node] = new Rect(Event.current.mousePosition + scrollPosition - rect.size / 2f, rect.size);
//                 GUI.changed = true;
//             }

//             nodeRects[node] = GUI.Window(node.RoomId, nodeRects[node], DrawNodeWindow, $"Habitación {node.RoomId}");

//             if (connectingNodes && selectedNode == node)
//             {
//                 Handles.DrawLine(nodeRects[node].center, Event.current.mousePosition);
//             }
//         }
//         EndWindows();
//     }


//   void DrawNodeWindow(int id)
//     {
//         RoomNode node = roomNodes[id];

//         // Mostrar información del nodo (opcional)
//         // EditorGUILayout.LabelField($"ID: {node.RoomId}");

//         // Limitar el número de conexiones
//         if (node.ConnectedRooms.Count < 2 || node == GetStartNode() || node == GetEndNode())
//         {
//             if (GUILayout.Button("Conectar"))
//             {
//                 selectedNode = node;
//                 connectingNodes = true;
//             }
//         }

//         //GUI.DragWindow(); // Eliminar para evitar conflicto con el movimiento del nodo
//     }
    
   
//     private void DrawConnections()
//     {
//         foreach (var kvp in roomNodes)
//         {
//             RoomNode node = kvp.Value;
//             Rect startRect = nodeRects[node];
//             foreach (RoomNode connectedNode in node.ConnectedRooms)
//             {
//                 if (roomNodes.ContainsKey(connectedNode.RoomId))
//                 {
//                     Rect endRect = nodeRects[connectedNode];
//                     Handles.DrawLine(startRect.center, endRect.center);
//                 }
//             }
//         }
//     }

//     private void DrawGrid()
//     {
//         Handles.color = Color.gray;

//         // Líneas verticales
//         for (float x = gridSize.x; x < position.width; x += gridSize.x)
//         {
//             Handles.DrawLine(new Vector3(x, 0f, 0f), new Vector3(x, position.height, 0f));
//         }

//         // Líneas horizontales
//         for (float y = gridSize.y; y < position.height; y += gridSize.y)
//         {
//             Handles.DrawLine(new Vector3(0f, y, 0f), new Vector3(position.width, y, 0f));
//         }

//         Handles.color = Color.white;
//     }

//     // ... (código existente)

//   private void ConnectNodes(RoomNode node1, RoomNode node2)
//     {
//         if (node1 != node2 && !node1.ConnectedRooms.Contains(node2) &&
//             node1.ConnectedRooms.Count < 2 && node2.ConnectedRooms.Count < 2)
//         {
//             node1.ConnectedRooms.Add(node2);
//             node2.ConnectedRooms.Add(node1);
//         }
//     }

//      private void ProcessEvents(Event e)
//     {
//         if (e.type == EventType.MouseDown && e.button == 0)
//         {
//             if (connectingNodes)
//             {
//                 // Buscamos si se hizo clic sobre otro nodo para conectar
//                 foreach (var kvp in roomNodes)
//                 {
//                     if (nodeRects[kvp.Value].Contains(e.mousePosition))
//                     {
//                         ConnectNodes(selectedNode, kvp.Value);
//                         break;
//                     }
//                 }
//                 connectingNodes = false;
//                 selectedNode = null;
//             }
//         }
//     }

//       private RoomNode GetStartNode()
//     {
//         // Busca el nodo con el ID 0 (o cualquier otro criterio para identificar el nodo de inicio)
//         foreach (var kvp in roomNodes)
//         {
//             if (kvp.Value.RoomId == 0)
//                 return kvp.Value;
//         }

//         return null;
//     }

//     private RoomNode GetEndNode()
//     { 
//         // Busca el nodo con el ID 1 (o cualquier otro criterio para identificar el nodo de fin)
//         foreach (var kvp in roomNodes)
//         {
//             if (kvp.Value.RoomId == 1)
//                 return kvp.Value;
//         }

//         return null;
//     }
}
