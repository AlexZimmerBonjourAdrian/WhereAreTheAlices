using UnityEngine;
using System.Collections.Generic; // For List

[CreateAssetMenu(fileName = "New Flashback Data", menuName = "Flashback Data")] // Easier creation in the editor
public class CFlashBackData : ScriptableObject
{
    /// <summary>
    /// Implements a flashback system.  Dialogue is linear.
    /// Allows navigation between scenes within the flashback.
    /// Acts as a separate game state.  Once finished, a flashback cannot be accessed again unless the game is replayed.
    ///You'll need a FlashbackManager script (probably a singleton) to handle the overall flashback state and logic. This manager should:

//Start Flashback: Called by CFlashBackData.StartFlashback(). It should pause the game, initialize the UI, and load the first scene in the provided CFlashBackData.
///Manage Scene Transitions: Handle loading the next scene in the Scenes list when the current scene's dialogue is finished.
///Display Dialogue: Manage the display of DialogueLines in the UI, including character names, text, and playing voice clips.
///Handle Navigation: Allow the player to navigate between scenes (e.g., using "Next" and "Previous" buttons), keeping track of their current position in the flashback.
///End Flashback: When the last scene and dialogue are finished, return to the normal game state.
    /// </summary>
    public int Id;
    public string FlashbackName; // Give each flashback a descriptive name

    // Scene Management
    public List<SceneData> Scenes; 

    [System.Serializable] // Make SceneData visible in the inspector
    public class SceneData
    {
        public string SceneName; // Scene to load (build index or scene path)
        public Sprite BackgroundImage; // Optional background image for the scene
        public List<DialogueLine> DialogueLines; // Dialogue for this scene
    }


    [System.Serializable]
    public class DialogueLine
    {
        public string CharacterName;
        [TextArea] public string DialogueText;
        public AudioClip VoiceClip; // Optional voice acting clip
    }


    [SerializeField, HideInInspector] private bool _hasPlayed = false;
    public bool HasPlayed => _hasPlayed;


    public void StartFlashback() // More descriptive method name
    {
        if (HasPlayed) return; // Don't replay in the same playthrough

       // FlashbackManager.Instance.StartFlashback(this);  // Use a FlashbackManager (see below)
        _hasPlayed = true;
    }

    
}


