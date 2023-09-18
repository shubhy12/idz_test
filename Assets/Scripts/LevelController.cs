using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Search;
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
    public PlayerExecutableContainer executableContainer;

    public bool IsGameOver { get; private set; }

    public int startX;
    public int startY;





    void Awake()
    {
        _instance = this;
        toDoGridController.Init(startX, startY);
        playerGridController.Init(startX, startY);
    }

    public bool isWon()
    {
        bool _isWon = true;
        for (int i = 0; i < toDoGridController.toDoMoveSequence.Count; i++)
        {
            if (toDoGridController.toDoMoveSequence[i] != playerGridController.playerMoveSequences[i])
            {
                _isWon = false;
                break;
            }

        }
        return _isWon;

    }

    public void Gameover(bool _isWon)
    {
        Debug.Log("GameOver!\n---------------------");
        IsGameOver = true;
        if (_isWon)
        {
            Debug.Log("Level Cleared!");
        }
        else
        {
            Debug.Log("Level Failed!");

        }
    }


}
