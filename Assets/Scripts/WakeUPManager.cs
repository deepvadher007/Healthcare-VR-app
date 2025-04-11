using UnityEngine;
using UnityEngine.UI;

public class WakeUpManager : MonoBehaviour
{
    public CanvasGroup fadePanel;     // from FadeCanvas
    public AudioSource wakeUpAudio;   // Optional
    public Transform wakeUpPoint;     // where XR Rig should move
    public GameObject xrRig;
    public float fadeDuration = 1f;

    public void OnRestButtonPressed()
    {
        StartCoroutine(WakeUpSequence());
    }

    private System.Collections.IEnumerator WakeUpSequence()
    {
        // Fade to black
        yield return StartCoroutine(FadeCanvas(0, 1));

        // Wait a bit
        yield return new WaitForSeconds(0.5f);

        // Move XR rig
        xrRig.transform.position = wakeUpPoint.position;
        xrRig.transform.rotation = wakeUpPoint.rotation;

        // Play audio if any
        if (wakeUpAudio != null)
            wakeUpAudio.Play();

        // Wait and fade in
        yield return new WaitForSeconds(1.5f);
        yield return StartCoroutine(FadeCanvas(1, 0));
    }

    System.Collections.IEnumerator FadeCanvas(float from, float to)
    {
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            fadePanel.alpha = Mathf.Lerp(from, to, elapsed / fadeDuration);
            yield return null;
        }
        fadePanel.alpha = to;
    }
}
