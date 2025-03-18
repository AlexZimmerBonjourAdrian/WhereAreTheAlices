using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using PointClickerEngine;
public static class CSaveLoadManager 
{
    //private static string savePath = Application.persistentDataPath + "/SaveFile.json";

     private static string savePath = "Assets/SaveData/SaveData.json"; 
   public static void SaveGame()
    {
         CGameData data = new CGameData();

        // Guardar datos de diálogo
        data.dialogueHistory = CManagerDialogue.Inst.getdialogueHistory();
        data.executedDialogues = CManagerDialogue.Inst.getexecutedDialogues();

        // Guardar variables de control
//        data.currentYarnProjectName = CManagerDialogue.Inst.GetYarnProject().name;
       // (data.floatVariables, data.stringVariables, data.boolVariables) = CManagerDialogue.Inst.dialogueSaver.GetAllVariables();

       
        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, jsonData);
         CGameManager.Inst. SaveDataUI.text = "Save Game Surcefull" + savePath;
    }

 
    public static void LoadGame()
    {
        if (File.Exists(savePath))
        {
            string jsonData = File.ReadAllText(savePath);
            GameData data = JsonUtility.FromJson<GameData>(jsonData);

            // // Cargar datos de diálogo
            // CManagerDialogue.Inst.dialogueHistory = data.dialogueHistory;
            // CManagerDialogue.Inst.executedDialogues = data.executedDialogues;

            // // Cargar variables de control
            // // Encuentra el Yarn Project por nombre y configúralo en CManagerDialogue
            // // ...
            // CManagerDialogue.Inst.dialogueSaver.SetAllVariables(data.floatVariables, data.stringVariables, data.boolVariables);

            // Cargar otros datos del juego
            // ...
        }
        else
        {
            // Manejar la carga de un nuevo juego si no existe un archivo de guardado
            // ...
        }
    }
   
}
