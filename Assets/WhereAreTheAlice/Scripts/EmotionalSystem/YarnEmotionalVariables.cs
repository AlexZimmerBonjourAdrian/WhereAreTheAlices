using UnityEngine;
using Yarn.Unity;
using System.Collections.Generic;

public class YarnEmotionalVariables : MonoBehaviour
{
    [YarnCommand("increment_emotion")]
    public static void IncrementEmotion(string character, string emotion, int amount)
    {
        EmotionalVariablesManager.Instance.IncrementEmotionTowardsPlayer(character, emotion, amount);
    }

    [YarnFunction("get_emotion")]
    public static int GetEmotion(string character, string emotion)
    {
        return EmotionalVariablesManager.Instance.GetEmotionTowardsPlayer(character, emotion);
    }
}