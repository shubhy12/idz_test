using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ToDoGridController : GridController
{

    [ContextMenu("Set Sequence")]
    public void SetSequence()
    {
        if (drawPath.Count == 0)
        {
            Debug.Log("No path specified");
            levelController.startX = 0;
            levelController.startY = 0;
            return;
        }

        int index = Array.IndexOf(Points, drawPath[0]);
        if (index == -1)
        {
            Debug.Log("point is not part of grid");
            levelController.startX = 0;
            levelController.startY = 0;
            return;
        }
        levelController.startY = index / MatrixValue;
        levelController.startX = index % MatrixValue;
        currX = levelController.startX;
        currY = levelController.startY;
        executedCommands.Clear();
        myLine.Reset();

        Vector2 prevPoint = drawPath[0].anchoredPosition;
        for (int i = 0; i < drawPath.Count; i++)
        {
            myLine.MakeLine(prevPoint, drawPath[i].anchoredPosition, Color.white);
            prevPoint = drawPath[i].anchoredPosition;

        }
    }
}


