using System.Collections;
using UnityEngine;

public class ScreenFader : MonoBehaviour
{
    public CanvasGroup fadePanel;

    public void FadeOutAndIn(System.Action onMidFade)
    {
        StartCoroutine(FadeRoutine(onMidFade));
    }

    IEnumerator FadeRoutine(System.Action onMidFade)
    {
        // Fade to black
        yield return StartCoroutine(Fade(0, 1));

        onMidFade?.Invoke(); // Teleport or do anything

        // Fade back to clear
        yield return StartCoroutine(Fade(1, 0));
    }

    IEnumerator Fade(float from, float to)
    {
        float duration = 1f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(from, to, elapsed / duration);
            fadePanel.alpha = alpha;
            yield return null;
        }

        fadePanel.alpha = to;
    }
}
