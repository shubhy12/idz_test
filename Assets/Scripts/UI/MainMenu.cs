using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnClickScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
    public void OnClose()
    {
        Application.Quit();
    }
}
