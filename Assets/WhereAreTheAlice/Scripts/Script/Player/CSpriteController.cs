using System.Collections;
using System.Collections.Generic;
using PointClickerEngine;
using UnityEngine;
using Yarn.Unity;

public class CSpriteController : MonoBehaviour
{
    [SerializeField] private List<Transform> childTransforms = new List<Transform>();
    
	[SerializeField] DialogueRunner runner;
    private int actualSprite;
    private void Awake()
    {
        LoadChildTransforms();
        runner = CManagerDialogue.Inst.GetDialogueRunner();
        runner.AddCommandHandler<int>("SpriteExtpesion", SetActiveSprite );

    }

    private void LoadChildTransforms()
    {
        childTransforms.Clear(); // Clear the list to avoid duplicates

        foreach (Transform child in transform)
        {
            childTransforms.Add(child);
        }

        // Optionally log the loaded transforms (useful for debugging)
        foreach (Transform childTransform in childTransforms)
        {
            Debug.Log("Loaded child transform: " + childTransform.name);
        }
    }



    //Example to Access to the list.
    public void PrintChildNames()
    {
        foreach(Transform child in childTransforms)
        {
            Debug.Log(child.name);
        }
    }



    // Optional:  If you need to refresh the list at runtime (e.g., if children are added or removed dynamically)
    public void RefreshChildTransforms()
    {
        LoadChildTransforms();
    }

    
    public  void SetActiveSprite(int SpriteExtpesion)
    {
        if (SpriteExtpesion >= 0 && SpriteExtpesion < childTransforms.Count)
        {
            childTransforms[SpriteExtpesion].gameObject.SetActive(true);
            actualSprite = SpriteExtpesion;
        }
        else
        {
            Debug.LogError("Invalid exprecion index: " + SpriteExtpesion);
        }
        for(int i = 0; i <=   childTransforms.Count-1; i++)
        {
            if( i != actualSprite)
            {
                  childTransforms[i].gameObject.SetActive(false);
            }
        }
    }

}
