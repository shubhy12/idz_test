using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public int MatrixValue = 4;
    public MyLine myLine;
    public RectTransform[] Points = new RectTransform[16];
    internal int currX;
    internal int currY;
    internal List<Command> executedCommands = new List<Command>();
    internal Move Up, Down, Left, Right;


    public void Init(int startX, int startY)
    {
        currX = startX;
        currY = startY;
        SetAvailableCommands();
    }

    public RectTransform GetCurrentPoint()
    {
        Debug.Log("currX " + currX + " currY " + currY);
        int index = (MatrixValue * currY) + currX;
        Debug.Log("index " + index);

        if (index < 0 || index >= Points.Length || Points[index] == null)
        {
            return null;
        }
        return Points[index];

    }
    public RectTransform GetNewPoint(int xInc, int yInc)
    {
        currX = currX + xInc;
        currY = currY + yInc;
        Debug.Log("currX " + currX + " currY " + currY);
        int index = (MatrixValue * currY) + currX;
        Debug.Log("index " + index);

        if (index < 0 || index >= Points.Length || Points[index] == null)
        {
            return null;
        }
        return Points[index];
    }

    public void DrawLine(int x, int y)
    {
        RectTransform t1 = GetCurrentPoint();
        RectTransform t2 = GetNewPoint(x, y);
        Debug.Log(" t1 " + t1 + " t2 " + t2);
        if (t1 == null || t2 == null)
        {
            NoMoveAction();
            return;
        }

        myLine.MakeLine(t1.anchoredPosition, t2.anchoredPosition, Color.white);

    }

    public virtual void NoMoveAction()
    {
        Debug.Log("Move not available");

    }

    public void SetAvailableCommands()
    {
        Up = new UP(MoveType.UP, this);
        Down = new DOWN(MoveType.DOWN, this);
        Right = new RIGHT(MoveType.RIGHT, this);
        Left = new LEFT(MoveType.LEFT, this);
    }
    public Move GetMove(MoveType _moveType)
    {
        switch (_moveType)
        {
            case MoveType.UP: return new UP(MoveType.UP, this);
            case MoveType.DOWN: return new DOWN(MoveType.DOWN, this);
            case MoveType.RIGHT: return new RIGHT(MoveType.RIGHT, this);
            case MoveType.LEFT: return new LEFT(MoveType.LEFT, this);
            default: return null;

        }
    }

    public void AddToExecuted(Command command)
    {
        executedCommands.Add(command);
    }

    private Vector3 GetWorldCoordinate(Vector3 pos)
    {
        Vector3 worldPos = new Vector3(pos.x, pos.y, 1);
        return Camera.main.ScreenToWorldPoint(worldPos);
    }
}
