using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void OT()
    {
        SceneManager.LoadScene("Operation Theatre");
    }

    public void Laboratory()
    {
        SceneManager.LoadScene("Laboratory");
    }

    public void HOME()
    {
        SceneManager.LoadScene("VR app");
    }
}
