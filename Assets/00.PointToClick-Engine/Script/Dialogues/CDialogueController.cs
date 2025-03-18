using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;


namespace PointClickerEngine
{
public class CDialogueController : MonoBehaviour
{
}


public interface ISkillCheckStrategy 
{
    bool CheckSkill(int statValue, int difficulty); 
}

public class DiceRollStrategy : ISkillCheckStrategy
{
    public bool CheckSkill(int statValue, int difficulty)
    {
        // Lógica actual de PerformAdvancedSkillCheck
        return false;
    }
}

public class PercentageRollStrategy : ISkillCheckStrategy
{
    public bool CheckSkill(int statValue, int difficulty)
    {
        // Lógica basada en porcentaje
        return false;
    }
}

#region Interfaces
//Comand pattern
public interface ICommand
{
    void Execute();
}
#endregion

}