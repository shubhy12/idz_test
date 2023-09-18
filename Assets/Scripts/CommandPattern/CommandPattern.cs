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


public abstract class Command
{

    //Move and maybe save command
    public abstract void Execute();

}
[Serializable]
public class Move : Command
{
    public MoveType moveType;
    internal GridController grid;

    public Move(MoveType _moveType, GridController _grid)
    {
        moveType = _moveType;
        grid = _grid;
    }

    public override void Execute()
    {

    }
    public void DrawLine(int x, int y)
    {
        grid.DrawLine(x, y);
    }

}

public class UP : Move
{
    public UP(MoveType _moveType, GridController _grid) : base(_moveType, _grid)
    {
    }

    public override void Execute()
    {
        DrawLine(0, -1);
    }


}
public class RIGHT : Move
{
    public RIGHT(MoveType _moveType, GridController _grid) : base(_moveType, _grid)
    {
    }

    public override void Execute()
    {
        DrawLine(1, 0);

    }

}
public class DOWN : Move
{
    public DOWN(MoveType _moveType, GridController _grid) : base(_moveType, _grid)
    {
    }

    public override void Execute()
    {
        DrawLine(0, 1);

    }

}
public class LEFT : Move
{
    public LEFT(MoveType _moveType, GridController _grid) : base(_moveType, _grid)
    {
    }

    public override void Execute()
    {
        DrawLine(-1, 0);

    }

}

