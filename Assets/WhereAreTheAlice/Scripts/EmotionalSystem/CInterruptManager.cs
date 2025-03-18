using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using PointClickerEngine;

public class CInterruptManager : MonoBehaviour
{
     

    [SerializeField] private Button interruptLeftButton;
    [SerializeField] private Button interruptRightButton;
    [SerializeField] private string interruptLeftNode = "InterruptLeft"; // Name of the Yarn node for left interrupt
    [SerializeField] private string interruptRightNode = "InterruptRight"; // Name of the Yarn node for right interrupt
    [SerializeField] private string interruptNode = "Interrupt"; // Name of the Yarn node for interrupt

    private DialogueRunner dialogueRunner;
    private bool canInterrupt = true;

   
    void Awake()
    {
        if(_inst != null && _inst != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        _inst = this;
    }
    

       public static CInterruptManager Inst
    {
        get
        {
            if (_inst == null)
            {
              
                GameObject obj = new GameObject("Game");
                return obj.AddComponent<CInterruptManager>();
            }

            return _inst;

        }
    }
    private static CInterruptManager _inst;
    private void Start()
    {
        dialogueRunner = CManagerDialogue.Inst.GetDialogueRunner();

        // Assign button actions
//        interruptLeftButton.onClick.AddListener(OnInterruptLeftButtonClicked);
   //     interruptRightButton.onClick.AddListener(OnInterruptRightButtonClicked);

        // Disable buttons initially
    //    interruptLeftButton.gameObject.SetActive(false);
      //  interruptRightButton.gameObject.SetActive(false);

        // Subscribe to events
        CGameEvents.OnDialogueStart.Subscribe(OnDialogueStart);
        CGameEvents.OnDialogueEnd.Subscribe(OnDialogueEnd);

        CGameEvents.OnInterruptDialogue.Subscribe(OnInterruptLeftButtonClicked);
        CGameEvents.OnPersuasiveDialogue.Subscribe(OnInterruptRightButtonClicked);

    }


    private void OnDialogueStart()
    {
        canInterrupt = true;
        interruptLeftButton.gameObject.SetActive(true);
        interruptRightButton.gameObject.SetActive(true);
    }

    private void OnDialogueEnd()
    {
        canInterrupt = false;
        interruptLeftButton.gameObject.SetActive(false);
        interruptRightButton.gameObject.SetActive(false);
    }

    public void OnInterruptLeftButtonClicked()
    {
        if (canInterrupt)
        {
            Interrupt(interruptLeftNode);
        }
    }

    public void OnInterruptRightButtonClicked()
    {
        if (canInterrupt)
        {
            Interrupt(interruptRightNode);
        }
    }

    private void Interrupt(string nodeName)
    {
        if (dialogueRunner.IsDialogueRunning)
        {
            dialogueRunner.Stop();
            CManagerDialogue.Inst.StartDialogueRunnerAcrossAllYarnProjects(nodeName);
        }
    }

}
