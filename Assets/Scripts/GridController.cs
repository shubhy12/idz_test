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
    public List<RectTransform> drawPath = new List<RectTransform>();
    [SerializeField]
    protected LevelController levelController;
    internal Move Up, Down, Left, Right;


    public void Init(int startX, int startY)
    {
        currX = startX;
        currY = startY;
        // playerPath.Add(GetCurrentPoint().transform);
        // SetAvailableCommands();
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

    public RectTransform GetPoint(int x, int y)
    {
        Debug.Log("currX " + x + " currY " + y);
        int index = (MatrixValue * y) + x;
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
        if (this is PlayerGridController)
        {
            Debug.Log("add player executed point to player path");
            drawPath.Add(t2);
            StartCoroutine(myLine.MovePencil(t1.position, t2.position));

        }
        myLine.MakeLine(t1.anchoredPosition, t2.anchoredPosition, Color.white);

    }

    public virtual void NoMoveAction()
    {
        Debug.Log("Move not available");

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
