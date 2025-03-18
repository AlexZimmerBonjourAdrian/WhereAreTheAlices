using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

namespace PointClickerEngine
{
[RequireComponent(typeof(CMICILSPSystem))]
public class CRoleplayDialogue : MonoBehaviour
{

    
    #region  YarnFunctions
   // Example of a more complex check with degrees of success
     [YarnFunction("GetStatByIndex")]
    public static bool PerformAdvancedSkillCheck(int statIndex, int difficulty)
    {
        int playerStat = CMICILSPSystem.Instance.GetStatByIndex(statIndex);
        int result = playerStat - difficulty;
        Debug.Log(result.ToString());

        if (result >= 3)
            return true; // Huge success!
        else if (result >= 0)
            return true;        // Standard success
        else if (result >= -3)
            return true; // Barely made it
        else
            return false;          // Clear failure
        // if (result >= 3)
        //     return "critical_success"; // Huge success!
        // else if (result >= 0)
        //     return "success";        // Standard success
        // else if (result >= -3)
        //     return "partial_success"; // Barely made it
        // else
        //     return "failure";   
    }
    [YarnFunction("GetCurrentArchetypeName")]
    public static string GetCurrentArchetypeName()
    {
        Debug.Log(CMICILSPSystem.Instance.CurrentStatsTemplate.Name);
        return CMICILSPSystem.Instance.CurrentStatsTemplate.Name;
    }


    
     [YarnCommand("SaveDialogue")]
     public static void SaveDialogue(string Dialogue)
    { 
         // CManagerDialogue.Inst.dialogueSaver.SaveDialogue(Dialogue);
    }

    [YarnCommand("SaveDialogueActual")]
    public static void SaveExecutedDialogue()
    { 
        string currentNodeName = CManagerDialogue.Inst.GetDialogueRunner().CurrentNodeName; 
       // string currentLine = CManagerDialogue.Inst.;
      //  Debug.Log(currentLine);
        // string currentLineText = currentLine.Text.Text; 

          //CManagerDialogue.Inst.dialogueSaver.SaveDialogue(currentLine);
    }

#endregion


    public static ISkillCheckStrategy skillCheckStrategy; 
    

    // En CRoleplayDialogue, puedes crear y ejecutar comandos
    public void PerformSkillCheck(ISkillCheckStrategy strategy, int statIndex, int difficulty)
    {
        ICommand command = new SkillCheckCommand(strategy, statIndex, difficulty);
        command.Execute();
    }

    //Pattern Strategy
    // Puedes cambiar la estrategia dinámicamente
    public static void SetSkillCheckStrategy(ISkillCheckStrategy strategy)
    {
        skillCheckStrategy = strategy;
    }

    
    public static bool PerformSkillCheck(int statIndex, int difficulty)
    {
        return skillCheckStrategy.CheckSkill(
            CMICILSPSystem.Instance.GetStatByIndex(statIndex), 
            difficulty
        );
    }

    // CRoleplayDialogue.SetSkillCheckStrategy(new LuckRollStrategy());
    // bool success = CRoleplayDialogue.PerformSkillCheck(statIndex, difficulty);
}

//Nuevo Commando
public class SkillCheckCommand : ICommand
{
    private ISkillCheckStrategy strategy;
    private int statIndex;
    private int difficulty;

    public SkillCheckCommand(ISkillCheckStrategy strategy, int statIndex, int difficulty)
    {
        this.strategy = strategy;
        this.statIndex = statIndex;
        this.difficulty = difficulty;
    }

    public void Execute()
    {
        bool success = strategy.CheckSkill(
            CMICILSPSystem.Instance.GetStatByIndex(statIndex),
            difficulty
        );

        // Manejar el resultado de la tirada
        if (success)
        {
            Debug.Log("La tirada fue excitosa");
        }
        else
        {
           Debug.Log("La tirada fallo");
        }
    }
}
}