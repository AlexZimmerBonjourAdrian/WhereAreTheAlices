using UnityEngine;

public class TestEmotionalVariablesManager : MonoBehaviour
{
    void Start()
    {
        // Asegurarse de que el EmotionalVariablesManager esté inicializado
        EmotionalVariablesManager.Instance.InitializeVariables("Alice");

        EmotionalVariablesManager.Instance.InitializeVariables("CB");

        EmotionalVariablesManager.Instance.InitializeVariables("Juno");
        // Incrementar una emoción
        EmotionalVariablesManager.Instance.IncrementEmotionTowardsPlayer("Alice", "$Confianza", 10);

        EmotionalVariablesManager.Instance.IncrementEmotionTowardsPlayer("CB", "$Confianza", 10);
        // Obtener el valor de una emoción
        int confianza = EmotionalVariablesManager.Instance.GetEmotionTowardsPlayer("Alice", "$Confianza");
        Debug.Log($"Confianza de Alice hacia el jugador: {confianza}");

        // Decrementar una emoción
        EmotionalVariablesManager.Instance.IncrementEmotionTowardsPlayer("Alice", "$Confianza", -5);

        // Obtener el valor actualizado de la emoción
        confianza = EmotionalVariablesManager.Instance.GetEmotionTowardsPlayer("Alice", "$Confianza");
        Debug.Log($"Confianza de Alice hacia el jugador después de decremento: {confianza}");
        EmotionalVariablesManager.Instance.IncrementEmotionTowardsPlayer("Juno", "$Confianza", -5);

         Debug.Log("La confianza de Juno es:" +EmotionalVariablesManager.Instance.GetEmotionTowardsPlayer("Juno", "$Confianza"));

         Debug.Log("La congianza de alice es: "+EmotionalVariablesManager.Instance.GetEmotionTowardsPlayer("Alice", "$Confianza"));

    }

}
