using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CDialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator _AnimatorPanel;
    public Animator _PlayerCharater;
    public Animator _PlayHolderCharacter;

    public Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();
    }
    // public void StartDialogue(CDialogue dialogue)
    // {
    //     Debug.Log("Entra en la funcion Star Dialogue");
    //     _AnimatorPanel.SetBool("IsConversation", true);
    //     _PlayerCharater.SetBool("IsConversation", true);
    //     _PlayHolderCharacter.SetBool("IsConversation", true);

    //     nameText.text = dialogue.name;
    //     sentences.Clear();
    //     foreach (string sentence in dialogue.sentences)
    //     {
    //         sentences.Enqueue(sentence);
    //     }
    //     DisplayNextSentence();

    // }
    //Control de Display del voton para Continuar la conversacion en una direccion

    //TODO:Crear sistema basico de tomas de desiciones en una sola funcion usando DisplayNextSentences como base
    //TODO:Estas tienen que ser posibles de ejecutar sin alteracciones por un solo boton
    //TODO:Investigar como hacer que el jugador pueda elegir diferentes opciones
    //TODO:investigar sobre events 
    //TODO: 
    public void DisplayNextSentence()
    {
        //Esto al ver que el contador de las sentencias llegue a 0 ejecuta la funcion finalizar conversacion
  
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        //Esto actualiza la caja de dialogo en ete caso hay que teer 
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }
    //Funcion ejecutada al terminar la conversacion Se puede especificar una animacion
    void EndDialogue()
    {
        _AnimatorPanel.SetBool("IsConversation", false);
        _PlayerCharater.SetBool("IsConversation", false);
        _PlayHolderCharacter.SetBool("IsConversation", false);
    }
}
