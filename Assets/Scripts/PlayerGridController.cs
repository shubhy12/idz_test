using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGridController : GridController
{
    public List<Move> playerMoves = new List<Move>();

    public List<MoveType> playerMoveSequences = new List<MoveType>();

    [ContextMenu("Run")]
    public void RunPlayerMoves()
    {
        executedCommands.Clear();
        myLine.Reset();
        for (int i = 0; i < playerMoveSequences.Count; i++)
        {
            if (LevelController.Instance.IsGameOver) return;
            Move m = GetMove(playerMoveSequences[i]);
            if (m == null)
            {
                break;
            }
            m.Execute();
            executedCommands.Add(m);
        }
        LevelController.Instance.Gameover(LevelController.Instance.isWon());
    }
    public override void NoMoveAction()
    {
        base.NoMoveAction();
        LevelController.Instance.Gameover(false);
    }

}
