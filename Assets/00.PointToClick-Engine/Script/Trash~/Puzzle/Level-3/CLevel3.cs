using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Yarn.Unity;
using PointClickerEngine;
public class CLevel3 : CLevelGeneric
{

    public static CDoor Door;

    public static List<GameObject> ListCharacters;

    
    public static CLevel3 Inst
    {
        get
        {
            if (_inst == null)
            {
                GameObject obj = new GameObject("Level3");
                return obj.AddComponent<CLevel3>();
            }

            return _inst;
        }
    }

    private static CLevel3 _inst;
    private void Awake()
    {
        Door = FindAnyObjectByType<CDoor>();
        
        
    }

    public void Start()
    {
        ListCharacters = FindObjectsOfType<CCharacter>().Select(Char => Char.gameObject).ToList();

          _inst = this;
    }

   [YarnCommand("EndTerror")]
    public static void EventEndTerror()
    {     
        Door.SetRoom(4);
        Door.SetThisLevelIsComplete(true);
    }


//Yarn Command with parameter functional
//  [YarnCommand("TestEvent")]
// public static void EventEndTerror(string terrorType) 
// {      
//     Debug.Log("Ending terror type: " + terrorType); // Example: prints the terror type
//     Door.SetRoom(4);
//     Door.SetThisLevelIsComplete(true);
// }
  
    public void DesactiveCharacter(int id)
    {
   
       for(int i = 0; i <= ListCharacters.Count-1; i++)
        {
            if(ListCharacters[i].GetComponent<CCharacter>().GetIDCharacter() == id)
            {
                ListCharacters[i].SetActive(false); 
            }
            
        }

    }


    

    [YarnCommand("NormalEnd")]
    public static void EventEndNormal()
    {
       Door.SetRoom(5);
       Door.SetThisLevelIsComplete(true);

    }


}
