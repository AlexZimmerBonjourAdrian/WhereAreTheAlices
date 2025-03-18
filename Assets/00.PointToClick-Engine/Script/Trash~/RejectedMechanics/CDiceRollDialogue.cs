using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;


namespace PointClickerEngine
{
[RequireComponent(typeof(CInterrogativeDialogue),typeof(CDebateDialogue),typeof(CMICILSPSystem))]
public class CDiceRollDialogue : MonoBehaviour
{
     // Method to roll the dice
    
    [YarnFunction("RollDice")]
    public static int RollDice()
    {
        // Six-sided dice roll
        return Random.Range(1, 7); 
    }

      // Method to check the dice roll result
    [YarnCommand("CheckDiceRoll")]
    public static void CheckDiceRoll(int diceRoll, int statint, int difficulty)
    {
        // Get the player's stat value
        int playerStat = CMICILSPSystem.Instance.GetStatByIndex(statint);

        // Calculate the total result
        int totalResult = playerStat + diceRoll;

        // Compare with the difficulty
        if (totalResult >= difficulty)
        {
            // Player wins
            Debug.Log("¡Has tenido éxito! Resultado: " + totalResult);
            CManagerDialogue.Inst.StopDialogueRunner();
            CManagerDialogue.Inst.StartDialogueRunner("DiceRoll_por_que_lo_mencionas");
        }
        else
        {
            // Player loses
            Debug.Log("Has fallado. Resultado: " + totalResult);
            CManagerDialogue.Inst.StopDialogueRunner();
            CManagerDialogue.Inst.StartDialogueRunner("DiceRoll_Por_que_deberia_confiar");
        }
    }

}
}
