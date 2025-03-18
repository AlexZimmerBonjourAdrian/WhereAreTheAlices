using UnityEngine;
using Yarn.Unity;
using System.Collections.Generic;

public class EmotionalVariablesManager : MonoBehaviour
{
    public static EmotionalVariablesManager Instance { get; private set; }

    private Dictionary<string, Dictionary<string, int>> characterEmotionsTowardsPlayer = new Dictionary<string, Dictionary<string, int>>();

    public int maxValue = 100;
    public int minValue = 0;

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

    [YarnCommand("InitializeVariables")]
    public void InitializeVariables(string characterName)
    {
        if (!characterEmotionsTowardsPlayer.ContainsKey(characterName))
        {
            characterEmotionsTowardsPlayer[characterName] = new Dictionary<string, int>
            {
                { "$Confianza", 0 },
                { "$Miedo", 0 },
                { "$Amor", 0 },
                { "$Estres", 0 },
                { "$Culpa", 0 },
                { "$Atraccion", 0 }
            };
        }
    }

    public void IncrementEmotionTowardsPlayer(string characterName, string emotionName, int amount)
    {
        InitializeVariables(characterName);

        if (characterEmotionsTowardsPlayer[characterName].ContainsKey(emotionName))
        {
            characterEmotionsTowardsPlayer[characterName][emotionName] = Mathf.Clamp(characterEmotionsTowardsPlayer[characterName][emotionName] + amount, minValue, maxValue);
            Debug.Log($"Emotion {emotionName} towards player by {characterName} incremented by {amount}. New value: {characterEmotionsTowardsPlayer[characterName][emotionName]}");
        }
        else
        {
            Debug.LogError($"Emotion '{emotionName}' not found for character '{characterName}'.");
        }
    }

    public int GetEmotionTowardsPlayer(string characterName, string emotionName)
    {
        if (characterEmotionsTowardsPlayer.ContainsKey(characterName) && characterEmotionsTowardsPlayer[characterName].ContainsKey(emotionName))
        {
            return characterEmotionsTowardsPlayer[characterName][emotionName];
        }
        else
        {
            Debug.LogError($"Emotion '{emotionName}' or character '{characterName}' not found.");
            return 0;
        }
    }

    [YarnCommand("IncrementEmotionTowardsPlayer")]
    public void IncrementEmotionTowardsPlayerYarn(string characterName, string emotionName, int amount)
    {
        IncrementEmotionTowardsPlayer(characterName, emotionName, amount);
    }

    [YarnCommand("GetEmotionTowardsPlayer")]
    public void GetEmotionTowardsPlayerYarn(string characterName, string emotionName, string variableName)
    {
        int emotionValue = GetEmotionTowardsPlayer(characterName, emotionName);
       // FindObjectOfType<DialogueRunner>().SetVariable(variableName, emotionValue);
    }
}