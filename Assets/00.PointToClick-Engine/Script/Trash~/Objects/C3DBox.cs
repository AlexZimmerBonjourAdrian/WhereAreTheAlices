using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class C3DBox : MonoBehaviour, Iinteract
{
   private Renderer rend; // Reference to the Renderer component
    
    public void Awake()
    {

        rend = GetComponent<Renderer>();
    }
     public void Oninteract()
    {
        // Get a random color from the array
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        // Set the object's color to the random color
        rend.material.color = randomColor;

        Debug.Log("Estoy Interactuando");
    }
}
