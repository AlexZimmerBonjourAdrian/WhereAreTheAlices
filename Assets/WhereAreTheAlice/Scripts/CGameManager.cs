using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wherearethealices
{
   public class CGameManager : MonoBehaviour
{
  
    public static CGameManager Inst
    {
        get
        {
            if (_inst == null)
            {
              
                GameObject obj = new GameObject("Game");
                return obj.AddComponent<CGameManager>();
            }

            return _inst;

        }
    }
    private static CGameManager _inst;


    void Awake()
    {
        if(_inst != null && _inst != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        _inst = this;
    }
//MVP GameStateMachine Finite Machine State Level
     public enum GameStates
    {
        none,
        MainMenu,
        MenuCase,
        Case,
        WinCondition,
        LoseCondition,

        FlashBack,
    }

    public GameStates state = GameStates.none;

   
  
    private void setState(int i)
    {
      GameStates Var = (GameStates)i;
        
        state = Var;
        
        switch((int)state)
        {
            case (int)GameStates.none:

            break;

            case (int)GameStates.MainMenu:

            break;

             case (int)GameStates.MenuCase:

            break;

             case (int)GameStates.Case:


            break;

             case (int)GameStates.WinCondition:

            break;

             case (int)GameStates.LoseCondition:

            break;

             case (int)GameStates.FlashBack:

            default:

            break; 
        };
    }


    //Huge GameFlow MainMenu -> MenuCases -> Case -> win or lose condition ->Repeate

    //Main GameFlow Case -> Animatic -> card -> cases Repeat or  win or lose condition -> repeate

    //Animatics Sequences images max 3 images to complement storytelling.

    //Card. it have two type of card one is a Trhee cards is a card a like rol system, you can decide to interrogatorie and you can decide change Resoult.

    //Two card, it is most importart about tree card,  why?, Because this card tell you, you previous choice Three cards is correct, and the storie follow a one succesfull but, you lisen all words the character speak, because you bad selection happen a bad end in the cases. focus all words.

    //Lose condition, don't unlock new cases, Cases is market to failed, and insist to retry, Played a Animatic how to lose your cases who die or other consecuences.

    //Win condition, Unlock cases 

    //There are cases in which story can change as a there are static, first case a like static is a started all storie.

    //You can change your Three card selection, in any moment excepto Two cards Selection.

    //But you can't retourn a previos Card Selection.


 }
}
