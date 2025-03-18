using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCardController : MonoBehaviour
{
    
     [SerializeField] private CanvasGroup ThreeCardsCanvasGroup;
     [SerializeField] private List<CCard> managedCards = new List<CCard>(); // Keep track of the cards



    public static CCardController Inst
    {
        get
        {
            if (_inst == null)
            {
                GameObject obj = new GameObject("CCardController");
                return obj.AddComponent<CCardController>();
            }

            return _inst;
        }
    }

    private static CCardController _inst;
    public void Start()
    {
    CCard[] cards = FindObjectsOfType<CCard>();
    managedCards.AddRange(cards);
     if (ThreeCardsCanvasGroup == null) // Check if it hasn't already been set in the inspector.
        {

           ThreeCardsCanvasGroup = GameObject.Find("ThreeCards").GetComponent<CanvasGroup>();

        
            if (ThreeCardsCanvasGroup == null)
            {
                Debug.LogError("CanvasGroup 'ThreeCards' not found!  Please ensure the object exists and has a CanvasGroup component.");
            }

        }

    }

     public void ShowCardMenu()
    {
        // Enable the card menu
        ThreeCardsCanvasGroup.alpha = 1;
        ThreeCardsCanvasGroup.interactable = true;
        ThreeCardsCanvasGroup.blocksRaycasts = true;   


    }

     public void HidderCardMenus() 
     {
         ThreeCardsCanvasGroup.alpha = 0;
        ThreeCardsCanvasGroup.interactable = false;
        ThreeCardsCanvasGroup.blocksRaycasts = false;  
     }

    public void ResetCards()
{
    foreach (CCard card in managedCards)
    {
        CDrag dragComponent = card.GetComponent<CDrag>();
        if (dragComponent != null)
        {
            dragComponent.ResetCardPosition(); // Call a new method on the CDrag component.
        }
    }

    // Find all slots and reset them as well
    CSlot[] slots = FindObjectsOfType<CSlot>(); 
    foreach (CSlot slot in slots)
    {
        slot.currentCard = null;
    }
}
}
