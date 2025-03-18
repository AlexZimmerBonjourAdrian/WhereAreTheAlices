using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using PointClickerEngine;

public class CLightController : MonoBehaviour
{
    // Start is called before the first frame update
// Start is called before the first frame update
    [SerializeField] private CanvasGroup BackGround;
    [SerializeField] private float fadeDuration = .2f; // Adjust fade duration as needed
    [SerializeField] private float blinkMinDuration = 0.1f;
    [SerializeField] private float blinkMaxDuration = 0.5f;
    [SerializeField]  DialogueRunner runner;

    private void Awake()
    {
        runner = CManagerDialogue.Inst.GetDialogueRunner();
           
        runner.AddCommandHandler("FadeInBackGround", FadeInBackGround );
          runner.AddCommandHandler("FadeOutBackGround", FadeOutBackGround );
            runner.AddCommandHandler("RandomBlinking", RandomBlinking);
              runner.AddCommandHandler("StopBlinking", StopBlinking );
    }

   
    private IEnumerator FadeInBackGround()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            BackGround.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        BackGround.alpha = 1f; // Ensure it reaches 1
    }

    private IEnumerator FadeOutBackGround()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            BackGround.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        BackGround.alpha = 0f; // Ensure it reaches 0
    }

 private IEnumerator RandomBlinking()
{
    var minBlinks = 3;
    var maxBlinks = 5;
    int blinkCount = Random.Range(minBlinks, maxBlinks + 1); // +1 because maxBlinks is exclusive

    for (int i = 0; i < blinkCount; i++)
    {
        BackGround.alpha = 0f;
        float randomDuration = Random.Range(blinkMinDuration, blinkMaxDuration);
        yield return new WaitForSeconds(randomDuration);

        BackGround.alpha = 1f;
        randomDuration = Random.Range(blinkMinDuration, blinkMaxDuration);
        yield return new WaitForSeconds(randomDuration);
    }

    // Optionally, you could add a final state here, like ensuring the light is on:
    // BackGround.alpha = 1f; 
}

    private IEnumerator StopBlinking()
    {
        StopCoroutine(RandomBlinking()); // Stop the blinking coroutine
        BackGround.alpha = 1f; // Turn the light back on (or to your desired default state)
        yield return null; // Required for a coroutine, even if empty.
    }


    // Example usage:
    // StartCoroutine(FadeInBackGround());
    // StartCoroutine(FadeOutBackGround());
    // StartCoroutine(RandomBlinking());
    // StartCoroutine(StopBlinking());
}
