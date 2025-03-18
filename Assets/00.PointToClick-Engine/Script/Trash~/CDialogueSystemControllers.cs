using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PointClickerEngine
{
    public class CDialogueSystemControllers : MonoBehaviour
    {
      
        [SerializeField] private List<GameObject> DialogueSystemList;

        
        public void ActivateDialogueSystem(int index)
        {
            for (int i = 0; i < DialogueSystemList.Count; i++)
            {
                DialogueSystemList[i].SetActive(false);
            }

            DialogueSystemList[index].SetActive(true);
            
        }
  
    public void Update()
    {
        //ControllerDialogue();
        switchDialogues();
    }
    
    public void switchDialogues()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            
          // CManagerDialogue.Inst.getDialogueRunner().Stop();
            ActivateDialogueSystem(0);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
          //  CManagerDialogue.Inst.getDialogueRunner().Stop();
            ActivateDialogueSystem(1);
        }
    }

    private void ControllerDialogue()
    {
        Debug.Log("GameStates: " + CGameManager.Inst.getState());
            switch (CGameManager.Inst.getState())
            {
                
                case (int)EStates.GameManagerState.DialogueState:
                    ActivateDialogueSystem(0);
                    break;
                case (int)EStates.GameManagerState.VisualNovelState:
                    ActivateDialogueSystem(1);
                    break;
            }
    }
    

    }

  
}