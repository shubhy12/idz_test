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
    public T GetMove<T>() where T : Move
    {
        return (T)this;
    }

    public void DrawLine(int x, int y)
    {
        LevelController.Instance.playerGridController.DrawLine(x, y);
    }

}