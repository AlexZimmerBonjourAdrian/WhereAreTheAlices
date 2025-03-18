using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class CFlashBackManager : MonoBehaviour
{
    /*
    Create a CFlashBackManager GameObject in your scene and attach this script.
Create CFlashBackData assets for each flashback, configuring scenes, dialogue, etc.
Call CFlashBackManager.Instance.StartFlashback(yourFlashbackData) from wherever you want to trigger a flashback (e.g., a button press, a trigger).
Connect the UI elements in the Inspector (dialogue text, background image, buttons).
Implement scene loading: Make sure your game can load scenes correctly using SceneManager.LoadSceneAsync or your chosen method.
    */
    public static CFlashBackManager Instance { get; private set; } // Singleton instance

    private CFlashBackData currentFlashback;
    private int currentSceneIndex = 0;
    // Add UI elements here (e.g., Text for dialogue, Image for background, Buttons for navigation)
    public UnityEngine.UI.Text dialogueText;
    public UnityEngine.UI.Image backgroundImage;
    public UnityEngine.UI.Button nextButton;
    public UnityEngine.UI.Button previousButton;



    private void Awake()
    {
        // Singleton implementation
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
            return;
        }


    }

    public void StartFlashback(CFlashBackData flashback)
    {
        currentFlashback = flashback;
        currentSceneIndex = 0;
        LoadCurrentScene();


        // Set up UI elements, etc. (Enable dialogue box, hide other UI)
        // ...

        // Deactivate player controls or pause the game
        // ...

    }

    private void LoadCurrentScene()
    {
        if (currentFlashback == null || currentFlashback.Scenes.Count == 0)
        {
            Debug.LogError("No flashback data or scenes found!");
            return;
        }



        CFlashBackData.SceneData currentScene = currentFlashback.Scenes[currentSceneIndex];
        // Load the scene (replace with your actual scene loading method)
        SceneManager.LoadSceneAsync(currentScene.SceneName);

        // Set the background image
        backgroundImage.sprite = currentScene.BackgroundImage;


        // Start displaying the dialogue for the current scene
        DisplayNextDialogueLine();

        // Update navigation buttons
        UpdateNavigationButtons();
    }

    private void DisplayNextDialogueLine()
    {
         CFlashBackData.SceneData currentScene = currentFlashback.Scenes[currentSceneIndex];


        if(currentScene.DialogueLines.Count > 0)
        {
            CFlashBackData.DialogueLine currentLine = currentScene.DialogueLines[0];
            dialogueText.text = currentLine.DialogueText;
            currentScene.DialogueLines.RemoveAt(0);
        }
        else
        {
            dialogueText.text = "";
        }
    }

    public void NextScene()
    {
        currentSceneIndex++;
        if (currentSceneIndex < currentFlashback.Scenes.Count)
        {
            LoadCurrentScene();
        }
        else
        {
            EndFlashback();
        }
        UpdateNavigationButtons();
    }

    public void PreviousScene()
    {
        currentSceneIndex--;
        if (currentSceneIndex >= 0)
        {
            LoadCurrentScene();
        }
        UpdateNavigationButtons();


    }

    private void UpdateNavigationButtons()
    {

        previousButton.interactable = currentSceneIndex > 0;
        nextButton.interactable = currentSceneIndex < currentFlashback.Scenes.Count - 1;


    }


    private void EndFlashback()
    {
        currentFlashback = null;
        currentSceneIndex = 0;

        // Unload flashback scenes, reactivate player controls, etc.
        // ...

        //Example of going back to the main scene (Scene 0)
        SceneManager.LoadSceneAsync(0);
    }



    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
           DisplayNextDialogueLine();

        }
    }
    
}

/*

// ... inside your CFlashBackManager ...

private AsyncOperation loadOperation;

private void LoadCurrentScene()
{
    // ... (Your existing code) ...

    CFlashBackData.SceneData currentScene = currentFlashback.Scenes[currentSceneIndex];
    // Load the scene additively:
    loadOperation = SceneManager.LoadSceneAsync(currentScene.SceneName, LoadSceneMode.Additive);
    loadOperation.allowSceneActivation = false; // Prevent scene from activating immediately

    // Wait until loading is complete (you may want to add a progress bar here):
    loadOperation.completed += OnFlashbackSceneLoaded;


    // Deactivate main scene elements (cameras, player, UI etc)
    // ... your code to disable main game components ...
}

private void OnFlashbackSceneLoaded(AsyncOperation operation)
{
    // Activate the flashback scene's elements (cameras, UI):
    // ... your code to enable flashback game components ...
    loadOperation.allowSceneActivation = true;

    operation.allowSceneActivation = true;


    // ... your code to start the flashback ...
}

private void EndFlashback()
{
    // ... (Your existing code) ...

    // Unload the flashback scene:
    SceneManager.UnloadSceneAsync(currentFlashback.Scenes[currentSceneIndex].SceneName);

    // Reactivate main scene elements (cameras, player, UI):
    // ... your code to enable main game components ...
    currentFlashback = null;
    currentSceneIndex = 0;
}

*/

/*
El código que proporcionas muestra dos controladores: CAnimaticController y CFlashBackManager. Ambos manejan secuencias de eventos, pero con diferentes propósitos y niveles de complejidad.

CAnimaticController se encarga de animaciones sencillas, mostrando secuencias de sprites con transiciones de fundido. Piensa en él como un sistema para pequeñas animaciones o escenas cortas que usan solo sprites, sin necesidad de cargar escenas completas de Unity. Utiliza un sistema de estados (AnimaticState) para controlar la reproducción (Reproduciendo, Pausado, Transición, Detenido) y emplea corrutinas (IEnumerator) para manejar las transiciones de fundido entre sprites. Su interacción con el jugador es sencilla, basada en eventos o en un clic del ratón (en modo depuración). Este controlador usa Yarn Spinner para gestionar el diálogo.

CFlashBackManager, por otro lado, está diseñado para gestionar flashbacks más complejos. Un flashback en este contexto es una secuencia de escenas completas de Unity, no sólo sprites. Cada escena del flashback puede contener diálogo, elementos de juego, y cualquier otra cosa que una escena de Unity normal pueda tener. CFlashBackManager carga y descarga escenas usando SceneManager.LoadSceneAsync. La clave aquí está en usar LoadSceneMode.Additive para cargar escenas adicionales sin reemplazar la escena actual. Esto es fundamental para que el flashback no interrumpa el juego principal.

La diferencia crucial está en cómo ambos manejan la carga de escenas:

CAnimaticController: No carga escenas. Sólo cambia sprites en el mismo GameObject.
CFlashBackManager: Carga y descarga escenas de Unity, lo cual es mucho más complejo. Requiere un manejo cuidadoso para evitar que el juego se congele y para asegurarse de que la escena del flashback y la escena principal no interfieran entre sí.
Para que el flashback funcione correctamente sin interrumpir el flujo del juego principal, CFlashBackManager debe:

Usar LoadSceneMode.Additive: Para cargar las escenas del flashback sin reemplazar la escena principal.
Desactivar/Activar elementos de la escena principal: Antes de iniciar el flashback, se debe desactivar la cámara principal, los controles del jugador, y cualquier otro elemento que pueda interferir con la reproducción del flashback. Al terminar el flashback, se reactivan.
Gestionar el estado del juego: Se necesita un mecanismo para pausar el juego principal mientras dura el flashback. Esto implica pausar la física, la lógica de los enemigos, y cualquier otro proceso del juego.
Manejar la UI: Se necesita una interfaz de usuario (UI) separada para el flashback. Esta UI se superpondría a la UI principal, pero solo se haría visible durante el flashback.
En resumen, ambos controladores comparten la idea de manejar una secuencia de elementos, pero CFlashBackManager tiene una complejidad significativamente mayor al manejar escenas completas de Unity y la integración con el juego principal de forma que no lo interrumpa. CAnimaticController es para animaciones simples, mientras que CFlashBackManager es para secuencias narrativas más elaboradas que involucran la carga y descarga de escenas de Unity.



*/



/*

There's no single, universally perfect way to deactivate everything in a Unity game, as the best approach depends on your game's architecture and how you've organized your game objects and scripts. However, here are several strategies you can employ, ranging from simple to more sophisticated:

1. Using a Game Manager or Global Script:

This is a common and relatively simple approach. Create a singleton script (a script that ensures only one instance exists throughout the game) that acts as your game manager. This script will have a method to pause the game. Your other scripts would listen for events or changes in a bool variable in the manager to suspend or resume their behavior.

// GameManager.cs (Singleton)
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool isGamePaused = false; //Flag to indicate game pause

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PauseGame()
    {
        isGamePaused = true;
        //Optional: Add additional pause actions here, e.g., timeScale = 0;
    }

    public void ResumeGame()
    {
        isGamePaused = false;
        //Optional: Add additional resume actions here, e.g., timeScale = 1;
    }
}


// Example usage in another script:
public class PlayerController : MonoBehaviour
{
    private void Update()
    {
        if (!GameManager.Instance.isGamePaused)
        {
            // Update player movement and other actions here
        }
    }
}
Use code with care. Learn more
2. Tagging Game Objects and Deactivating them:

Assign a tag (e.g., "GameplayObject") to all game objects you want to deactivate during the flashback. Then, use a script to find all game objects with that tag and disable them:

public class FlashbackPauseManager : MonoBehaviour
{
    public void PauseGameplay()
    {
        GameObject[] gameplayObjects = GameObject.FindGameObjectsWithTag("GameplayObject");
        foreach (GameObject go in gameplayObjects)
        {
            go.SetActive(false); // Deactivate for the duration of the flashback.
        }
    }

    public void ResumeGameplay()
    {
        GameObject[] gameplayObjects = GameObject.FindGameObjectsWithTag("GameplayObject");
        foreach (GameObject go in gameplayObjects)
        {
            go.SetActive(true); // Reactivate when the flashback ends.
        }
    }
}
3. Using Layers and Layer Masks (For Physics):

If you want to specifically disable physics interactions, use layers and layer masks. Assign all objects participating in physics to a specific layer, create a layer mask that excludes this layer, and use this mask when performing physics checks during the flashback. This is more specific than deactivating objects entirely and prevents unnecessary overhead if you just want to disable certain physical interactions, not all aspects of gameobjects.

4. Component-Based Deactivation:

If you have many scripts controlling different aspects of your game (movement, AI, etc.), you might create a custom interface or base class, and in your scripts implement this interface that will have a "Pause" method. In the FlashbackPauseManager, then you will iterate through all of your components in your scene and call this pause method on them. This provides more fine-grained control.

Choosing the Right Approach:

Simple Games: A GameManager with a isGamePaused flag is sufficient.
Medium Complexity Games: Tagging and deactivation might be more suitable.
Complex Games with lots of different systems: The component-based approach offers the finest level of control and flexibility.
Important Considerations:

Cleanup: Remember to re-enable or reactivate all paused or deactivated elements at the end of the flashback to prevent unexpected behavior.
Event System: Consider using Unity's event system or a custom event system to notify different parts of your game about the pause and resume events. This is cleaner than checking a global flag in every Update() method.
Testing: Thoroughly test your pause/resume system to ensure all aspects of your game are correctly handled.
Remember to integrate whichever method you choose with your CFlashBackManager to pause the game at the start of the flashback and resume it at the end. This is necessary to avoid strange and unexpected behavior from your game.


*/