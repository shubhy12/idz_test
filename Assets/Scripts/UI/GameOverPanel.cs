using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public TextMeshProUGUI heading;

    public void ShowGameOver(bool won)
    {
        gameObject.SetActive(true);
        if (won)
        {
            heading.text = "Level Cleared!";
        }
        else
        {
            heading.text = "Failed!";
        }
    }

    public void OnClickRestar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoToHome()
    {
        SceneManager.LoadScene(0);
    }
}
