using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSlot : MonoBehaviour
{
     public CCard currentCard; // Add this line
    
   private bool hasAddedInput = false; // Flag to track if input has been added

    public void Update()
    {
        
        if (currentCard != null && hasAddedInput == false) // Check if card exists AND input hasn't been added yet
        {
            Debug.Log("Entra? " + "Slot");
            CCase01.Inst.addInput(currentCard.CardData.ValueUniverseSequence);
            hasAddedInput = true; // Set the flag to prevent further input
        }
        else if (currentCard == null) // if the card is removed, reset the flag.
        {
            hasAddedInput = false;
        }
    }
}
