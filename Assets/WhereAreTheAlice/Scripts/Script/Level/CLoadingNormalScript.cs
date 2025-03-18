using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // If using UI elements

public class CLoadingNormalScript : MonoBehaviour
{
    [SerializeField] private Image loadingBar; // Optional: Visual loading bar
    [SerializeField] private Text loadingText;   // Optional: Loading text

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    
    public void LoadSceneAsync(int index)
    {
        StartCoroutine(LoadSceneAsyncCoroutine(index));
    }

    private IEnumerator LoadSceneAsyncCoroutine(int index)
    {
        // Optional: Show loading UI elements
       
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        operation.allowSceneActivation = false; // Prevent automatic scene activation


        // Optional: Briefly wait before activating the new scene (for visual smoothness, if using a loading bar)
        yield return new WaitForSeconds(0.5f); 
        operation.allowSceneActivation = true;  // Activate the new scene

    }
}
