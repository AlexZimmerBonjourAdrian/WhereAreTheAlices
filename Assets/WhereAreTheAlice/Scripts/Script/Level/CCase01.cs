using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Yarn.Unity;
using PointClickerEngine;
using System.Linq;
public class CCase01 : CLevelGeneric
{

    //Case 01 MVP Logic 
    //Todo:Logic Card to CardController and CardManager.


  

    [SerializeField]
    private List<int> SequencePuzzle;
    
    
    [SerializeField]
    private List<List<int>> CorrectSequences; // Renamed to plural

    
    
    //SetterManually
    [SerializeField] public TextMeshProUGUI DebugTextSequence;
    [SerializeField] public TextMeshProUGUI DebugTextState;
    private bool isSuccesfull = false;
    private bool isComplete  = false;



    //BranchDialogueList
    
    public enum CardInputType
{
    TwoCards,
    ThreeCards
}

[SerializeField]
private CardInputType cardInputType;
    public static CCase01 Inst
    {
        get
        {
            if (_inst == null)
            {
                GameObject obj = new GameObject("CCase01");
                return obj.AddComponent<CCase01>();
            }

            return _inst;
        }
    }

    private static CCase01 _inst;


    public void Awake()
    {
        
         SequencePuzzle = new List<int>();
        _inst = this;

        SetState(3);

    }
 

  private void SetState(int state)
{
    SequencePuzzle.Clear(); // Clear any existing sequence
    isComplete = false;
    isSuccesfull = false;
    DebugTextState.text = ""; // Clear debug text
    DebugTextSequence.text = "";


    switch (state)
    {
        case 2:
            cardInputType = CardInputType.TwoCards;
            CorrectSequences = new List<List<int>>
            {
                new List<int> { 1, 2 },
                new List<int> { 2, 1 }
            };
            break;

        case 3:
            cardInputType = CardInputType.ThreeCards;
            CorrectSequences = new List<List<int>>
            {
                new List<int> { 2, 1, 3 },
                new List<int> { 3, 1, 2 }
            };
            break;

        default:
            Debug.LogError($"Invalid state: {state}.  Must be 2 or 3.");
            break;
    }
}
 public void addInput(int code)
{
    if (isComplete != true)
    {
        SequencePuzzle.Add(code);

        int expectedCount = (cardInputType == CardInputType.TwoCards) ? 2 : 3;

        if (SequencePuzzle.Count == expectedCount)
        {
            UpdateTextSequence();
            Checksuccessful();
            isComplete = true; 
        }
    }
}

 public void Checksuccessful()
{
    bool foundMatch = false;

    //  Handle empty input or incomplete sequence
    if (SequencePuzzle.Count == 0 || SequencePuzzle.Count < ((cardInputType == CardInputType.TwoCards)? 2 : 3))
    {
        DebugTextState.text = "Incomplete Sequence";
        return;
    }
    

    foreach (var correctSequence in CorrectSequences)
    {
        //Ensure that you only compare with sequences of the correct length.
        if (correctSequence.Count == SequencePuzzle.Count && SequencePuzzle.SequenceEqual(correctSequence)) 
        {
            foundMatch = true;
            break; 
        }
    }

    if (foundMatch)
    {
        DebugTextState.text = "Correct Sequence";
        SuccesfullSequence();
    }
    else
    {
        DebugTextState.text = "Incorrect Sequence";
        ResetSequence();
    }
}




   private void SuccesfullSequence()
   {
       // Determine the dialogue to run based on the successful sequence
        string dialogueToRun = DetermineDialogueBasedOnSequence();

        if (dialogueToRun != null)
        {
            ExecuteDialogueBranch(dialogueToRun);
        }
        else
        {
            Debug.LogError("No dialogue defined for the completed sequence.");
        } 
   }

     private string DetermineDialogueBasedOnSequence()
    {
        // Add logic here to determine which dialogue to run based on the completed SequencePuzzle
        // For example:
       
    if (cardInputType == CardInputType.ThreeCards && SequencePuzzle.Count == 3)
        {
                    
                
            if (SequencePuzzle.SequenceEqual(new List<int> { 3, 2, 1 }))
                {
                    return "StartIntroduction";
                }
            
                else
                {
                    return null; // Return null if no matching sequence is found.
                }
            
        }
    
    
    else if (cardInputType == CardInputType.TwoCards && SequencePuzzle.Count == 2)
        {
            if (SequencePuzzle.SequenceEqual(new List<int> {1, 2}))
            {
                return "StartIntroduction"; 
            }
           
            else
            {
                return null; // Return null if no matching sequence is found.
            }
        }
        else 
        {
            return null;
        }

        
    }
   void Update()
   {
        InputKeyBoardSequence();
   }
   //Debug Functions

   private void InputKeyBoardSequence()
   {
    //roust Logic KeyBoard
    if(Input.GetKeyDown(KeyCode.R))
    {
        ResetSequence();
    }

   }

   private void UpdateTextSequence()
   {
    for(int i = 0; i < SequencePuzzle.Count; i++)
    {
        DebugTextSequence.text = SequencePuzzle[i].ToString();
        Debug.Log(SequencePuzzle[i].ToString());
    }
   
   }

    private void ResetSequence()
    {
        SequencePuzzle.Clear();
        // DebugTextState.text = " ";
        // DebugTextSequence.text = " ";    
        
        isSuccesfull = false;

        isComplete = false; 

        CCardController.Inst.ResetCards(); 



    }
  

public void ExecuteDialogueBranch(string DialogFind)
{
    // Assuming CManagerDialogue is a singleton or accessible statically.
    string foundNode = CManagerDialogue.Inst.FindNodeReturnNodeAcrossAllYarnProjects(DialogFind);

    if (foundNode != null)
    {
        DialogueRunner dialogueRunner = FindObjectOfType<DialogueRunner>();
        if (dialogueRunner != null)
        {
         dialogueRunner.Stop();
         CManagerDialogue.Inst.StartDialogueRunnerAcrossAllYarnProjects(foundNode);
        }
        else
        {
            Debug.LogError("Dialogue Runner not found in the scene.");
        }
    }
    else
    {
        Debug.LogError($"Yarn node '{DialogFind}' not found.");
    }
}

[YarnCommand("Case01EndSuccesfull")]
public static void EndSuccesfull()
{
    CLevelManager.Inst.LoadScene(1);
}

    

}
