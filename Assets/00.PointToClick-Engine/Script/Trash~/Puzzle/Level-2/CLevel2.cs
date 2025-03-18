using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//using Patterns.GameEvents;

public class CLevel2 : CLevelGeneric
{
   
    [SerializeField] 
    private List<GameObject> POV;

    [SerializeField] 
    private List<GameObject> Mesa;
   
    [SerializeField]
    public List<int> RouteNormalRoom;

    private  bool EnterSound = false;

     [SerializeField]
    public List<GameObject> LevelRooms;

   // Lista de todas las rooms

    private int currentRoomIndex; // Índice de la room actual
    
    [SerializeField]
    private List<int> CorrectSequence;
    
    [SerializeField]
    private bool IsTakeShootgun;
    
    [SerializeField]
    private bool IsRevolver;
    [SerializeField]
    private bool IsMagRevolver;
    [SerializeField]
    private bool IsShootGunShell;

    [SerializeField]
    private bool IsFinished;

    [SerializeField]
    private bool IsTakeCard;

    [SerializeField]
    private bool IsShootMusicBox;

    private int ActualRoom = 0;

    public static CLevel2 Inst
    {
        get
        {
            if (_inst == null)
            {
                GameObject obj = new GameObject("Level2");
                return obj.AddComponent<CLevel2>();
            }

            return _inst;
        }
    }

    private static CLevel2 _inst;


    public void Awake()
    {
         _inst = this;
          var PovObject = GameObject.FindGameObjectWithTag("POV");
          var MesaObject =  GameObject.FindGameObjectWithTag("Mesa");

         LevelRooms = GetComponentsInChildren<Room>(true) // Include inactive children
                                  .Select(room => room.gameObject) // Select the GameObject
                                  .ToList();
         
          POV = PovObject.GetComponentsInChildren<CMovementPlayer>(true) // Include inactive children
                                  .Select(CMovementPlayer=> CMovementPlayer.gameObject) // Select the GameObject
                                  .ToList();
         
          Mesa = MesaObject.GetComponentsInChildren<CMovementPlayer>(true) // Include inactive children
                                  .Select(CMovementPlayer => CMovementPlayer.gameObject) // Select the GameObject
                                  .ToList();
        
     
    }


 public void Start()
{
   
    SetRoomActive(0);
    SetMesaActive(0);
    SetPovActive(0);
}

#region SetterAndGetter
public void SetIsShootMusicBox(bool aBool)
{
    IsShootMusicBox = aBool;
}

public void SetIsTakeShootgun(bool aBool)
{
    IsTakeShootgun = aBool;
}

public void SetIsRevolver(bool aBool)
{
    IsRevolver = aBool;
}

public void SetIsFinished(bool aBool)
{
    IsFinished = aBool;
   
}
public void SetIsMagRevolver(bool aBool)
{
    IsMagRevolver = aBool;
}

public void SetIsTakeCard(bool aBool)
{
    IsTakeCard = aBool;
     CGameEvents.OnCompleteLevel.Publish(true);
}

public void SetIsShootGunShell(bool aBool)
{
    IsShootGunShell = aBool;
}
public bool GetIsShootMusicBox()
{
   return IsShootMusicBox;
}

public bool GetIsRevolver()
{
    return IsRevolver;
}

public bool GetIsMagRevolver()
{
    return IsMagRevolver;
}

public bool GetIsTakeShootGun()
{
    return IsTakeShootgun;
}

public bool GetIsShootGunShell()
{
    return IsShootGunShell;
}

public bool GetIsFinishLevel()
{
  
    return  IsFinished;
}
#endregion
public void SetRoomActive(int roomIndex, bool isActive= true)
    {
        if (roomIndex >= 0 && roomIndex < LevelRooms.Count)
        {
            LevelRooms[roomIndex].SetActive(isActive);
            ActualRoom = roomIndex;
            RouteNormalRoom.Add(ActualRoom);
        }
        else
        {
            Debug.LogError("Invalid room index: " + roomIndex);
        }
        for(int i = 0; i <=  LevelRooms.Count-1; i++)
        {
            if( i != ActualRoom)
            {
                 LevelRooms[i].SetActive(false);
            }
        }
    }

    public void SetPovActive(int roomIndex, bool isActive = true)
    {
        if (roomIndex >= 0 && roomIndex < POV.Count)
        {
            POV[roomIndex].SetActive(isActive);      
        }
        else
        {
            Debug.LogError("Invalid room index: " + roomIndex);
        }
        for(int i = 0; i <=  POV.Count-1; i++)
        {
            if( i != roomIndex)
            {
                 POV[i].SetActive(false);
            }
        }

    }

        public void SetMesaActive(int roomIndex, bool isActive = true)
    {
        if (roomIndex >= 0 && roomIndex < Mesa.Count)
        {
            Mesa[roomIndex].SetActive(isActive);      
        }
        else
        {
            Debug.LogError("Invalid room index: " + roomIndex);
        }
        for(int i = 0; i <=  Mesa.Count-1; i++)
        {
            if( i != roomIndex)
            {
                Mesa[i].SetActive(false);
            }
        }

    }
     public int GetCurrentRoomIndex()
     {
         return currentRoomIndex;
     }

    public void Update()
    {
        if(GetIsShootGunShell() == true && GetIsShootGunShell() && EnterSound == false)
        {
            CManagerSFX.Inst.PlaySound(8);
            EnterSound = true;
        }
    }


    
}
