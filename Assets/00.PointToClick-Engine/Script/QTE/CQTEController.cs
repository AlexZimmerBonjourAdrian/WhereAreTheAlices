using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CQTEController : MonoBehaviour
{
/// <summary>
///El sistema de QTE abstracto funciona, ahora se completara la logica del KeyPressQTE para ser utilizada en difetentes tipos de eventos QTE
///Se podran crear SubClases de este Tipo para Comportamiento cuasi similar, El mantener la presion en un juego en concreto
///Se probara con una barra Una barra y un debug de lo que se quiere
///Por ultimo se debera mover al motor del juego como un nuevo añadido.
///En cuanto a als interfaces se debe analizar como se pueden cargar de manera automatica, tal vez con el uso de un controller de recursos.
///
/// </summary>
    
public enum QTEState
{
    None,
    Start,
    Player,
    Finish
}


    // public CanvasGroup QTEInterface;
    

    // public TextMeshProUGUI Counter;

    // public TextMeshProUGUI Force;

    // public TextMeshProUGUI Result;

    public CQTEData Data;

    private CQTEBase qte;
    private QTEState currentState = QTEState.None;
    public void SetState(QTEState state)
    {
        currentState = state;
    }

    
    void Start()
    {
       if(qte == null)
         qte = CreateQTEInstance(Data);
         StartQTE();

    }

    public void StartQTE()
    {
        if (qte == null)
        {
            Debug.LogError("QTE is not initialized!");
            return;
        }

        // Use a lambda expression to wrap the IEnumerator
        StartCoroutine(qte.EjecuteQTE(Data)); 
    }
  
    private CQTEBase CreateQTEInstance(CQTEData data)
    {
        switch (data.TypePuzzle)
        {
            case QTETypePuzzle.KeyPress:
                
                return new KeyPressQTE();
            case QTETypePuzzle.Sequence:
                return new SequenceQTE(); // Assuming you create this class
            case QTETypePuzzle.Selection:
                return new SelectionQTE(); // Assuming you create this class
            default:
                return null; // Or throw an exception
        }
    }


 

    
}
