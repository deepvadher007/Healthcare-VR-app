using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTeleportTrigger : MonoBehaviour
{
    public string targetSceneName;
    private bool isTeleporting = false;

    void OnTriggerEnter(Collider other)
    {
        if (!isTeleporting && other.CompareTag("Player"))
        {
            isTeleporting = true;
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
