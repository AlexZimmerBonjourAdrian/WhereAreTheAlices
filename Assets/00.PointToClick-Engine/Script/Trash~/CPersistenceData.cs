using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.IO;
public class CPersistenceData : MonoBehaviour
{

   private static CPersistenceData _instance;
    private string savePath;
    
    
   public static CPersistenceData Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("CMICILSPSystem");
                _instance = obj.AddComponent<CPersistenceData>();
                DontDestroyOnLoad(obj); 
            }
            return _instance;
        }
    }

        public CMICILSPSystem.StatTemplate CurrentStatsTemplate { get; private set; } 
    // Start is called before the first frame update
     private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);

        savePath = Path.Combine(Application.persistentDataPath, "gamedata.json"); 

    }

   public void SetArquetipe(int i)
   {
    switch (i)
    {
        case 0:

         CMICILSPSystem.Instance.ApplyTemplate(CMICILSPSystem.Instance.Detective);
        break;

        case 1:

         CMICILSPSystem.Instance.ApplyTemplate(CMICILSPSystem.Instance.HeroinaDeCapaBlanca); 
         break;
           case 2:
         CMICILSPSystem.Instance.ApplyTemplate(CMICILSPSystem.Instance.LocaPerturbada); 
         break;
         
           case 3:
         CMICILSPSystem.Instance.ApplyTemplate(CMICILSPSystem.Instance.MonstruoSinCorazon); 
         break;
    }
       

   }
    public void SaveGame()
    {
        // GameData data = new GameData();
        // data.IsTakeShootgun = .Inst.GetIsTakeShootGun(); // Get data from CLevel2
   

        // string jsonData = JsonUtility.ToJson(data, true); // Serialize to JSON
        // File.WriteAllText(savePath, jsonData);
        // Debug.Log("Game saved to: " + savePath);
    }

    public void SaveDataArquetipe()
    {
            CMICILSPSystem.StatTemplate statTemplate = null;
            statTemplate = CMICILSPSystem.Instance.GetStatTemplate();   
            CMICILSPSystem.Instance.PrintStats(statTemplate);  

    }
}

[System.Serializable] // Make this class serializable
public class GameData
{

    public bool IsTakeShootgun;
    
    
    public bool IsRevolver;
    
    public bool IsMagRevolver;
    
    public bool IsShootGunShell;


    public bool IsFinished;


    public bool IsTakeCard;


    public bool IsShootMusicBox;


}