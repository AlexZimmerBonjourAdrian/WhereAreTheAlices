using UnityEngine;
using System.IO;


[System.Serializable]
public static class CSaveSystem 
{
      public static void SavePlayer(CPlayer player)
    {
        // Create a CPlayerData object to hold the data
        CPlayerData data = new CPlayerData(player);

        // Convert the CPlayerData object to JSON
        string jsonData = JsonUtility.ToJson(data);

        // Save the JSON data to a file
        string path = "Assets/SaveData/player.json";
        File.WriteAllText(path, jsonData);
    }
     public static CPlayerData LoadPlayer()
    {
        // Load the JSON data from the file
        string path =  "Assets/SaveData/player.json";
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);

            // Deserialize the JSON data back into a CPlayerData object
            CPlayerData data = JsonUtility.FromJson<CPlayerData>(jsonData);
            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }

     // string path = "/SaveData/player.txt";
}


