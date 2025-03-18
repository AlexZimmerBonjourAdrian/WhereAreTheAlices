using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 originalPosition;
    private Transform originalParent;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private CSlot currentSlot; // Track the current slot the card is in (or null if none)


    void Start()
    {
        originalPosition = transform.position;
        originalParent = transform.parent;
        canvas = FindObjectOfType<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        // If starting in a slot, record it
        if (transform.parent && transform.parent.TryGetComponent<CSlot>(out CSlot slot))
        {
            currentSlot = slot;
        }



    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(canvas.transform);
        canvasGroup.blocksRaycasts = false;

        // If card is currently in a slot, clear it from the slot
        if(currentSlot)
        {
            currentSlot.currentCard = null;
            currentSlot = null;
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        // Raycast to check for a CSlot under the mouse
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);


        CSlot closestSlot = null;
        float closestDistance = Mathf.Infinity;

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.TryGetComponent<CSlot>(out CSlot slot))
            {
               if(slot.currentCard == null)
               {
                    //calculate distance from card's center to the slot's center
                    float distance = Vector3.Distance(transform.position, slot.transform.position);

                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestSlot = slot;

                    }
               }

            }
        }


        if (closestSlot != null)
        {

            // Place the card in the slot
            transform.SetParent(closestSlot.transform);
            transform.position = closestSlot.transform.position;
            
            // Update the currentSlot and the closestSlot's card
            currentSlot = closestSlot;
            closestSlot.currentCard = GetComponent<CCard>();
            


        }

        else
        {
            // No valid slot found, return to original parent or specific position
            transform.SetParent(originalParent);
            transform.position = originalPosition;
           

        }

    }

     public void ResetCardPosition() 
    {
        transform.SetParent(originalParent);
        transform.position = originalPosition;
        currentSlot = null; 
    }

}