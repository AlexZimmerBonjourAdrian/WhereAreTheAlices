using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
//[SerializeField]
namespace PointClickerEngine
{
public class CCharacter : MonoBehaviour, Iinteract
{
    [SerializeField]
    
    protected Animator anim;
    //private bool isActiveAnim = false;

    [SerializeField]
    protected  int id;


    [SerializeField]
    protected string CharacterName;

    [SerializeField] private List<string> barkNodes;


    [Header("Assets"), Tooltip("all assets used character to demostrated expreccion")]
	public List<Sprite> loadSprites = new List<Sprite>();

    public List<AudioClip> loadAudio = new List<AudioClip>();

    private SpriteRenderer characterSpriteRenderer;
      
    [SerializeField]
    private bool isVisualNovel = false;
   
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
        characterSpriteRenderer = GetComponent<SpriteRenderer>();
       
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //Check Flags is CGameManager
        // CManagerDialogue.Inst.GetDialogueRunner().AddCommandHandler<string, string>("SetExpressionCharacter", SetExpressionCharacter);
       // CManagerDialogue.Inst.GetDialogueRunner().AddCommandHandler<int, string>("SetExpressionCharacterIndex", SetExpressionCharacterIndex);
        if(!CGameManager.Inst.GetFlag("DeathMoffin") && !CGameManager.Inst.GetFlag("DeathLoop") )
        {
            characterSpriteRenderer.sprite = loadSprites[0];
        }
          Debug.Log(CharacterName);

    }

    // Update is called once per frame
    public virtual void Oninteract()
    {   
      CManagerSFX.Inst.PlaySound(0);
//      CCameraManager.Inst.GetCamera1().gameObject.SetActive(true);
     // CGameManager.Inst.setState((int)EStates.GameManagerState.DialogueState);


    if(isVisualNovel == false)
    {
      if(!CManagerDialogue.Inst.GetIsDialogueRunning())
      {
            CManagerDialogue.Inst.SetGameMode(CManagerDialogue.GameMode.PointAndClick);
          CManagerDialogue.Inst.SetListYarn(id);
          CManagerDialogue.Inst.StartDialogueRunner(0);
      }

      else 
      {
         
         CManagerDialogue.Inst.StopDialogueRunner();
         CManagerDialogue.Inst.SetListYarn(id);
         CManagerDialogue.Inst.StartDialogueRunner(0);
      }

    }

    else
    {
        if(!CManagerDialogue.Inst.GetIsDialogueRunning())
      {
          CManagerDialogue.Inst.SetGameMode(CManagerDialogue.GameMode.VisualNovel);
          CManagerDialogue.Inst.SetListYarn(id);
          CManagerDialogue.Inst.StartDialogueRunner(0);
      }

      else 
      {
       
         CManagerDialogue.Inst.StopDialogueRunner();
         // CManagerDialogue.Inst.getDialogueSystemControllers().ActivateDialogueSystem(1);
         CManagerDialogue.Inst.SetListYarn(id);
         CManagerDialogue.Inst.StartDialogueRunner(0);
      }
      
      
      
    }
   

    }

    public virtual int GetIDCharacter()
    {
        return id;
    }

  // Nombres de los nodos de bark en Yarn Spinner
    public void PlayRandomBark()
    {
        if (barkNodes.Count == 0) return;

      int randomIndex = UnityEngine.Random.Range(0, barkNodes.Count);
        string barkNode = barkNodes[randomIndex];

        CManagerDialogue.Inst.StartDialogueRunner(barkNode);
    }

    
	#region YarnCommands

   
    public void SetExpressionCharacter(string characterName, string spriteName)
    {
     
         Debug.LogError(characterName);
        // Only execute if the character name matches
        if (characterName != CharacterName)
        {
            Debug.LogError("El nombre no coincide");
            
            return;
        }

        Sprite targetSprite = loadSprites.Find(sprite => sprite.name == spriteName);

        if (targetSprite == null)
        {
             Debug.LogError($"Sprite '{spriteName}' not found for character '{characterName}'");
            return;
        }
        
        characterSpriteRenderer.sprite = targetSprite; 
    }


    public string getCharacterName()
    {
        return CharacterName;
    }

    public bool getisVisualNovel()
    {
        return isVisualNovel;
    }

    public void SetExpressionCharacterIndex(int spriteIndex, string characterName)
    {
        // Only execute if the character name matches
        if (characterName != CharacterName)
        {
            return;
        }

        if (spriteIndex < 0 || spriteIndex >= loadSprites.Count)
        {
            Debug.LogWarning($"Invalid sprite index '{spriteIndex}' for character '{characterName}'");
            return;
        }

        characterSpriteRenderer.sprite = loadSprites[spriteIndex]; 
    } 
    #endregion

 }
}


