using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveType
{
    NONE,
    UP,
    DOWN,
    RIGHT,
    LEFT
}

public class CommanPattern : MonoBehaviour
{
    private static CommanPattern _instance;
    public static CommanPattern Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("CommanPattern is Null");
            }
            return _instance;
        }
    }





    void Awake()
    {
        _instance = this;


    }

}


public abstract class Command : MonoBehaviour
{

    //Move and maybe save command
    public abstract void Execute();

}
[Serializable]
public class Move : Command
{

    public override void Execute()
    {

    }
    public void DrawLine(int x, int y)
    {
        LevelController.Instance.playerGridController.DrawLine(x, y);
    }

}