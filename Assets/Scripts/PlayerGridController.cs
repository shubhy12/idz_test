using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerGridController : GridController
{
    public List<Move> playerMoves = new List<Move>();

    public List<Move> playerMoveSequences = new List<Move>();

    [ContextMenu("Run")]
    public async void RunPlayerMoves()
    {
        currX = levelController.startX;
        currY = levelController.startY;
        drawPath.Clear();
        drawPath.Add(GetCurrentPoint());

        executedCommands.Clear();
        myLine.Reset();
        for (int i = 0; i < playerMoveSequences.Count; i++)
        {
            if (levelController.IsGameOver) return;
            if (playerMoveSequences[i] == null)
            {
                break;
            }
            playerMoveSequences[i].Execute();
            executedCommands.Add(playerMoveSequences[i]);
            await Task.Delay(1000);
        }

        levelController.Gameover(levelController.isWon());
    }
    public override void NoMoveAction()
    {
        base.NoMoveAction();
        levelController.Gameover(false);
    }



}
