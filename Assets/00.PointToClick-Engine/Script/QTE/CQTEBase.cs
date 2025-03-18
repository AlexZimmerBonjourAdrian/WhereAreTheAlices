using System.Collections;
using Unity.Android.Gradle.Manifest;
using UnityEngine;



public abstract class CQTEBase
{


     public enum StateResultQTE { FailDramatico, Sucessfull, SucessfullFailed }

    public abstract StateResultQTE QTEReturnState();
    public abstract void StopQTE();
    public abstract IEnumerator EjecuteQTE(CQTEData data);

}





    public class KeyPressQTE : CQTEBase
{



    /// <summary>
/// Sistema de secuencia de QTEKeyPress comportament
/// 
/// Tengo los elemntos nesesarios para trabajaralo, 
/// Defini clases abractas para luego ser definidas en el QTE y sobrescritas segun lo que se nesecite o lo que pida el QTEDATA
/// Todo para no repetir codigo y ser reutilizada una y otra ves, todas las funciones son genericas para que funcionene en todos los tipos de QTE pero los variables no lo son.
/// Estas son especificas del QT
/// Ahora gemini quiero que me digas si algo puede estar faltando
/// </summary>

    public StateResultQTE stateResultQTE;
    private Coroutine runningCoroutine; // To store the running coroutine
    float elapsedTime = 0f;


   public override IEnumerator EjecuteQTE(CQTEData data) // Use the non-generic IEnumerator
    {

        float elapsedTime = 0f;
        bool qteSuccessful = false;

        while (elapsedTime < data.Duration)
        {
            elapsedTime += Time.deltaTime;

            if (Input.GetKeyDown(data.KeyToPress)) // Check for correct key press
            {
                qteSuccessful = true;
                break; // Exit the loop if successful
            }

            yield return null;
        }

        if (qteSuccessful)
        {
            Debug.Log("QTE Success!");
            // Handle QTE success, e.g., play animation, progress dialogue
        }
        else
        {
            Debug.Log("QTE Failure!");
            // Handle QTE failure
        }

        // Optionally reset the state:
       
    }

   

    public override StateResultQTE QTEReturnState()
    {
        return stateResultQTE;
    }

    public override void StopQTE()
    {
     

           
    }
    
}







    


public class SequenceQTE : CQTEBase
    {
        public override IEnumerator EjecuteQTE(CQTEData data)
        {
            Debug.Log("Starting Sequence QTE");
            // Implement sequence QTE logic here...
            yield break; // Placeholder. Replace with actual sequence logic.
        }

    public override StateResultQTE QTEReturnState()
    {
        throw new System.NotImplementedException();
    }

    public override void StopQTE()
        {
            Debug.Log("Stop");
        }

         
    }

    // Example of a SelectionQTE class (you'll need to implement the actual logic)
    public class SelectionQTE : CQTEBase
    {
        public override IEnumerator EjecuteQTE(CQTEData data)
        {
            Debug.Log("Starting Selection QTE");
            // Implement selection QTE logic here...
            yield break;  // Placeholder. Replace with actual selection logic.
        }

    public override StateResultQTE QTEReturnState()
    {
        throw new System.NotImplementedException();
    }

    public override void StopQTE()
        {
            Debug.Log("Stop");
        }

    
    }


