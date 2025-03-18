using UnityEngine;

public class DialogueTrigger : MonoBehaviour, Iinteract
{
    public string dialogueStartNode;
    public void Oninteract(){
        FindObjectOfType<Yarn.Unity.DialogueRunner>().StartDialogue(dialogueStartNode);
    }
    private void OnMouseDown()
    {
       Oninteract();
    }
}

