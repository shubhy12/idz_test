using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDoGridController : GridController
{
    public List<MoveType> toDoMoveSequence = new List<MoveType>();
    [SerializeField]
    LevelController levelController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    [ContextMenu("Set Sequence")]
    private void SetSequence()
    {
        executedCommands.Clear();
        myLine.Reset();
        currX = levelController.startX;
        currY = levelController.startY;

        for (int i = 0; i < toDoMoveSequence.Count; i++)
        {
            if (toDoMoveSequence[i] != MoveType.NONE)
            {
                Move m = GetMove(toDoMoveSequence[i]);
                m.Execute();
                executedCommands.Add(m);
            }
            else
            {
                Debug.Log("Wrong Sequence Set");
                executedCommands.Clear();
                myLine.Reset();
                break;

            }
        }
    }
}
