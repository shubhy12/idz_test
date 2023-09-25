using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class NestedMove : Move
{
    public Move childMove;
    public int loopingVal;
    public override void Execute()
    {
        LoopMove();
    }

    async void LoopMove()
    {
        for (int i = 0; i < loopingVal; i++)
        {
            childMove.Execute();
            await Task.Delay(LevelController.Instance.drawStepWaitingTimeMillies);
        }
    }
}
