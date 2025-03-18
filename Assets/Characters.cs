//     // Inicializa las variables (se llama en Awake)
//     private void InitializeVariables()
//     {
//         // Aquí se definen las variables y sus valores iniciales
//         emotionalVariables.Add("$Odio_CB", 0);
//         emotionalVariables.Add("$Confianza_Cheshire", 50);
//         // ... añade más variables aquí ...
//     }

//     // Incrementa el valor de una variable
//     public void IncrementVariable(string variableName, int amount)
//     {
//         if (emotionalVariables.ContainsKey(variableName))
//         {
//             emotionalVariables[variableName] += amount;
//              Debug.Log($"Variable {variableName} incrementada en {amount}. Nuevo valor: {emotionalVariables[variableName]}");
//         }
//         else
//         {
//             Debug.LogError($"Variable '{variableName}' no encontrada.");
//         }
//     }

//     // Decrementa el valor de una variable
//     public void DecrementVariable(string variableName, int amount)
//     {
//         IncrementVariable(variableName, -amount); // Reutilizamos el metodo para reducir el codigo
//     }

//     // Obtiene el valor actual de una variable
//     public int GetVariableValue(string variableName)
//     {
//         if (emotionalVariables.ContainsKey(variableName))
//         {
//             return emotionalVariables[variableName];
//         }
//         else
//         {
//             Debug.LogError($"Variable '{variableName}' no encontrada.");
//             return 0; // Valor por defecto si no existe
//         }
//     }
using System;
using System.Collections;
// using System.Collections.Generic;
 using UnityEngine;
// using UnityEngine.Rendering;

public class Characters : MonoBehaviour, Iinteract
{
    public void Oninteract()
    {
        
    }
}
