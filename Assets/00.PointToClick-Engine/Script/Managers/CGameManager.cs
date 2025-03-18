using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

using TMPro;
using UnityEngine.UI;
using UnityEngine.TextCore.Text;
using System.Linq;
namespace PointClickerEngine
{
public class CGameManager : MonoBehaviour
{
    // Referencias a otros managers


    // Estados del juego
   // [SerializeField] private int currentLevel;
    //[SerializeField] private int playerLives;
private int states= 0;

    [SerializeField] private bool IsEndGame;

        public CManagerSFX sfxManager;

    
   
    [SerializeField]
    public TextMeshProUGUI SaveDataUI;
    
    private GameObject PlayerGameobject;
    
    private List<CCharacter> ListCharacterClicked; 
    
 
    //Example to declaration an integrate
    //CGameState currentState = states[GameState.Playing];
    //currentState.Enter();  

    private Dictionary<string, bool> gameFlags = new Dictionary<string, bool>();

    // Singleton
     public static CGameManager Inst
    {
        get
        {
            if (_inst == null)
            {
                GameObject obj = new GameObject("GameManager");
                return obj.AddComponent<CGameManager>();
            }
            return _inst;

        }
    }
    private static CGameManager _inst;


    private AsyncOperation _CurrentLoadScene;
    
   public void Awake()
    {
    if(_inst != null && _inst != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        _inst = this;
        InitializeFlags();
   
    }
#region  Flags System
     // Método para obtener el valor de una flag
    public bool GetFlag(string flagName)
    {
        if (gameFlags.ContainsKey(flagName))
        {
            return gameFlags[flagName];
        }
        else
        {
            Debug.LogError("Flag no encontrada: " + flagName);
            return false;
        }
    }

    public void SetFlag(string flagName, bool value)
    {
        if (gameFlags.ContainsKey(flagName))
        {
            gameFlags[flagName] = value;
        
        //posible implementacion futura
            // if (value) 
            // {
            //     gameFlags[flagName] = !gameFlags[flagName];
            // }
            // Publicar evento al cambiar el valor de la flag
          
            switch (flagName)
            {
                case "PickupRevolver":
                    CGameEvents.OnPickupRevolver.Publish(); 
                    break;
                case "PickupShootGun":
                    CGameEvents.OnPickupShootGun.Publish();
                    break;
                case "PickupMag":
                    CGameEvents.OnPickupMag.Publish();
                    break;
                case "CombineRevolver":
                    CGameEvents.OnCombineRevolver.Publish();
                    break;
                case "ReloadShootgun":
                    CGameEvents.OnReloadShootgun.Publish();
                    break;
                case "ReloadRevolver":
                    CGameEvents.OnReloadRevolver.Publish();
                    break;
                case "DeathMoffin":
                    CGameEvents.OnDeathMoffin.Publish();
                    break;
                case "DeathLoop":
                    CGameEvents.OnDeathLoop.Publish();
                    break;
                case "GameLevel0Complete":
                    CGameEvents.OnGameLevel0Complete.Publish();
                    break;
                case "GameLevel1Complete":
                    CGameEvents.OnGameLevel1Complete.Publish();
                    break; 
                case "GameLevel2Complete":
                    CGameEvents.OnGameLevel2Complete.Publish();
                    break;
                case "GameLevel3Complete":
                    CGameEvents.OnGameLevel3Complete.Publish();
                    break;
                case "GameLevel4Complete":
                    CGameEvents.OnGameLevel4Complete.Publish();
                    break;
                case "GameLevel5Complete":
                    CGameEvents.OnGameLevel5Complete.Publish();
                    break;
                case "GameLevel6Complete":
                    CGameEvents.OnGameLevel6Complete.Publish();
                    break;
                case "GameLevel7Complete":
                    CGameEvents.OnGameLevel7Complete.Publish();
                    break;
                case "GameLevel8Complete":
                    CGameEvents.OnGameLevel8Complete.Publish();
                    break;
                case "GameLevel9Complete":
                    CGameEvents.OnGameLevel9Complete.Publish();
                    break;
                case "GameLevel10Complete":
                    CGameEvents.OnGameLevel10Complete.Publish();
                    break;
                case "GameFinish":
                    CGameEvents.OnGameFinish.Publish();
                    break;
            }
        }
        else
        {
            Debug.LogError("Flag no encontrada: " + flagName);
        }
    }
    #endregion

    #region Inicializate
    
    void Start()
    // Métodos para inicializar y finalizar el juego 
    {
        
        setState((int)EStates.GameManagerState.Playing);   
        //SaveUi
        SaveDataUI = GameObject.Find("SaveFlag").GetComponent<TextMeshProUGUI>();
        SaveDataUI.text = "Ready!";

        PlayerGameobject = GameObject.FindGameObjectWithTag("Player"); 
       
        CMICILSPSystem.Instance.ApplyTemplate(CMICILSPSystem.Instance.Detective);



      //   InitializeFlags();
   
        // Inicializar el estado del juego
        //ChangeState(GameState.MainMenu);

    //    CGameState currentState = states[GameState.Playing];
    //     currentState.Enter();
    }
    #endregion

   
 private void InitializeFlags()
    {
        gameFlags.Add("PickupRevolver",false);
        gameFlags.Add("PickupShootGun",false);
        gameFlags.Add("PickupMag", false);
        gameFlags.Add("CombineRevolver",false);
        gameFlags.Add("ReloadShootgun", false);
        gameFlags.Add("ReloadRevolver", false);
        gameFlags.Add("DeathMoffin",false);
        gameFlags.Add("DeathLoop",false);
        gameFlags.Add("GameLevel0Complete", false);
        gameFlags.Add("GameLevel1Complete", false);
        gameFlags.Add("GameLevel2Complete", false); 
        gameFlags.Add("GameLevel3Complete", false);
        gameFlags.Add("GameLevel4Complete", false);
        gameFlags.Add("GameLevel5Complete", false);
        gameFlags.Add("GameLevel6Complete", false);
        gameFlags.Add("GameLevel7Complete", false);
        gameFlags.Add("GameLevel8Complete", false);
        gameFlags.Add("GameLevel9Complete", false);
        gameFlags.Add("GameLevel10Complete", false);
        gameFlags.Add("GameFinish",false);
    }

void Update()
{
    switch(getState())
    {
      case (int)EStates.GameManagerState.Playing:
      Debug.Log((int)EStates.GameManagerState.Playing);
                 PlayingState();
                break;

         case (int)EStates.GameManagerState.DialogueState:
                 DialogueState();
                break;

         case (int)EStates.GameManagerState.VisualNovelState:
                VisualNovelState();
                break;
    }
}
void VisualNovelState()
{
    ListCharacterClicked = null;
   // setState((int)GameState.Playing);
}

void DialogueState()
{
    if (ListCharacterClicked == null) 
        {
            ListCharacterClicked = new List<CCharacter>();
        }
        
        if(Input.GetMouseButtonDown(0))
        {
             
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                CCharacter characterClick = hit.collider.GetComponent<CCharacter>();
                
                
                if(characterClick != null)
                {
                    characterClick.Oninteract();
                    ListCharacterClicked.Add(characterClick);
                }
            }

            Debug.Log(ListCharacterClicked);
            if(ListCharacterClicked.Count > 1)
            {
            if ((ListCharacterClicked[0].getCharacterName() == "Loop" &&
                    ListCharacterClicked[1].getCharacterName() == "Moffin") ||
                    (ListCharacterClicked[0].getCharacterName() == "Moffin" &&
                    ListCharacterClicked[1].getCharacterName()== "Loop"))
                    {
                        setState((int)EStates.GameManagerState.VisualNovelState);
                    }
            }
     }
}

void PlayingState()
{
  
       if(Input.GetMouseButtonDown(0))
        {
           
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                CGameEvents.OnGameDialogueRunner.Publish();
                CCharacter characterClick = hit.collider.GetComponent<CCharacter>();
                if(characterClick != null)
                {
                     setState((int)EStates.GameManagerState.DialogueState);
                }
            }
        }
}


public int getState()
{
    return states;
}

public void setState(int newState)
    {
        states = (int)newState;
        switch (newState)
        {
            case (int)EStates.GameManagerState.MainMenu:
                    Debug.Log("None Code");
                break;
            case (int)EStates.GameManagerState.Playing:
                 Debug.Log("DialogueState" + EStates.GameManagerState.Playing);
               
                break;
            case (int)EStates.GameManagerState.Paused:
                 Debug.Log("None Code");
                break;
            case (int)EStates.GameManagerState.GameOver:
                 Debug.Log("None Code");
                break;
            case (int)EStates.GameManagerState.DosState:
                Debug.Log("None Code");
                break;
            case (int)EStates.GameManagerState.TresState:
               Debug.Log("None Code");
                break;
            case (int)EStates.GameManagerState.DialogueState:
              Debug.Log("DialogueState" + EStates.GameManagerState.DialogueState);
                break;
            case (int)EStates.GameManagerState.FPSState:
                 Debug.Log("None Code");
                break;
            case (int)EStates.GameManagerState.InventorieState:
                 Debug.Log("None Code");
                break;
            case (int)EStates.GameManagerState.VisualNovelState:
              Debug.Log("DialogueState" + EStates.GameManagerState.VisualNovelState);
                break;
            case (int)EStates.GameManagerState.OpenWorldState:
                 Debug.Log("None Code");
                break;
            case (int)EStates.GameManagerState.PuzzleState:
                 Debug.Log("None Code");
                break;
        }
    }


//State pattern GameState
public abstract class CGameState  
{ 
  protected  CGameManager gameManager; // Variable para acceder al GameManager

        // Constructor que recibe el GameManager
        public CGameState(CGameManager gameManager) 
        {
            this.gameManager = gameManager;
        }

        // Métodos abstractos que deben ser implementados por las clases hijas
        public virtual void Enter()
        {

        }
        public virtual void Update()
         {

         }
        public virtual void Exit()
        {

        }

    }


}
}
