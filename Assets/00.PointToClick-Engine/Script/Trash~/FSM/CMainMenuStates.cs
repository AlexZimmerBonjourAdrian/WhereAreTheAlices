using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PointClickerEngine;
public class CMainMenuState : CGameManager.CGameState
{
    public CMainMenuState(CGameManager gameManager) : base(gameManager) { }

    public override void Enter()
    {
        // Activate main menu UI
        // Play main menu music
        Debug.Log("Entering Main Menu State"); 
    }

    public override void Update()
    {
        // Handle main menu input (New Game, Load, Options, etc.)
        if (Input.GetKeyDown(KeyCode.Space))
        {
           // gameManager.SwitchState(GameState.Playing);
        }
    }

    public override void Exit()
    {
        // Deactivate main menu UI
        Debug.Log("Exiting Main Menu State"); 
    }
}
