using UnityEngine;

public class LevelController : MonoBehaviour
{
    private static LevelController _instance;

    public static LevelController Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("LevelController is Null");
            }
            return _instance;
        }
    }

    public ToDoGridController toDoGridController;
    public PlayerGridController playerGridController;
    public ExecutableCommandContainer executableContainer;

    public GameOverPanel gameOverPanel;

    public bool IsGameOver { get; private set; }

    public int drawStepWaitingTimeMillies = 1000;

    public int startX;
    public int startY;





    void Awake()
    {
        _instance = this;
        // toDoGridController.Init(startX, startY);
        // playerGridController.Init(startX, startY);
        playerGridController.myLine.pencil.transform.position = playerGridController.GetPoint(startX, startY).position;
    }

    public bool isWon()
    {
        if (toDoGridController.drawPath.Count != playerGridController.drawPath.Count) return false;   //path count not match
        for (int i = 0; i < toDoGridController.drawPath.Count; i++)
        {
            Debug.Log("i " + i + " todo " + toDoGridController.drawPath[i].gameObject.name + " player " + playerGridController.drawPath[i].gameObject.name);
            if (!toDoGridController.drawPath[i].anchoredPosition.Equals(playerGridController.drawPath[i].anchoredPosition))
            {
                return false;
            }

        }
        return true;

    }

    public void Gameover(bool _isWon)
    {
        Debug.Log("GameOver!\n---------------------");
        IsGameOver = true;
        gameOverPanel.ShowGameOver(_isWon);
    }


}
