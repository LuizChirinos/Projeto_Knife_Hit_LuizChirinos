using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadLevel(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }

    public void AccessURL(string url)
    {
        Application.OpenURL(url);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
