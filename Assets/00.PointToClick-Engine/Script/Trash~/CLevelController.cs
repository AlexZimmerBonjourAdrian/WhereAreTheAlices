using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLevelController : MonoBehaviour
{
    [Header("Level Number")]
    [SerializeField]
    private ELevel.LevelNumber LevelNumber;


    [Space(20f)]
    [Header("LevelType")]
    private ELevel.LevelType LevelType;
    
    private CLevelGeneric Level;

    public static CLevelController Inst
    {
        get
        {
            if (_inst == null)
            {
                Debug.Log("Entra?");
                GameObject obj = new GameObject("Level");
                return obj.AddComponent<CLevelController>();
            }
          //  Debug.Log("Entra en el return");
            return _inst;

        }
    }
    private static CLevelController _inst;

    public void Awake()
    {
    if(_inst != null && _inst != this)
        {
            Destroy(gameObject);
            return;
        }
       // DontDestroyOnLoad(this.gameObject);
        _inst = this;
    }
    public void checkCompleteLevel()
    {

      switch((int)LevelNumber)
       {
            case 0:
                Level = (CLevel1)FindAnyObjectByType<CLevelGeneric>();
                
                if (Level.GetIsComplete())
                {
                  
                }
                break;
              
            case 1:
                Level = (CLevel1)FindAnyObjectByType<CLevelGeneric>();
                
                if (Level.GetIsComplete())
                {
                     
                    Debug.Log("Entra en el complete del nivel 1");
                    CDoor OBJ = FindAnyObjectByType<CDoor>();
                    CManagerSFX.Inst.PlaySound(3);
                    OBJ.SetThisLevelIsComplete(Level.GetIsComplete());
                    CGameEvents.OnActivateDoor.Publish();
                }
                break;
            case 2:
                Level = (CLevel2)FindAnyObjectByType<CLevelGeneric>(); 
                break;
            case 3:
                Level = (CLevel3)FindAnyObjectByType<CLevelGeneric>(); 
                break;
            case 4:
                 Level = (CLevelDialogue)FindAnyObjectByType<CLevelGeneric>(); 
                break;
            default:
                Debug.Log("No existen el nivel");
                break;
        };
       
    }

public int GetLevel()
{
    return ((int)LevelNumber);
}

public ELevel.LevelType GetLevelType()
{
    return LevelType;
}
        


}
