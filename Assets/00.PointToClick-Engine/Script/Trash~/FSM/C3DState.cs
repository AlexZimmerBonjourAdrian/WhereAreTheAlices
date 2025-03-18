using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PointClickerEngine;
public class C3DState :CGameManager.CGameState
{
   public C3DState(CGameManager gameManager) : base(gameManager) { }

    public override void Enter()
    {
        // Load level
        // Initialize player
        // Start gameplay music
        Debug.Log("Entering Playing State"); 
    }

    public override void Update()
    {
        // Handle player input
        // Update game logic
        // Check for game over or pause conditions
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //gameManager.SwitchState(GameState.Paused);
        }
    }

    public override void Exit()
    {
        // Save game progress (if needed)
        // Stop gameplay music
        Debug.Log("Exiting Playing State"); 
    }
}
