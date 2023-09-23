using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExecutableSequencingContainer : ExecutableCommandContainer
{
    public SimpleDrop[] slots;
    // Start is called before the first frame update
    void Start()
    {
        SetSlotIds();
    }


    void SetSlotIds()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].id = i;
            LevelController.Instance.playerGridController.playerMoveSequences.Add(null);
        }
    }

    public override void AddCommandToSequence(Transform slot, Transform Command)
    {
        SimpleDrop drop = slot.GetComponent<SimpleDrop>();
        SimpleDrag drag = Command.GetComponent<SimpleDrag>();
        Debug.Log("Adding Command " + Command.name + " to " + slot.name);
        SimpleDrag newDragCommand = Instantiate(drag, slot.transform);
        drop.currentDrag = newDragCommand;
        newDragCommand.transform.position = newDragCommand.startPosition = slot.transform.position;
        newDragCommand.dragImage.raycastTarget = true;
        LevelController.Instance.playerGridController.playerMoveSequences[drop.id] = Command.GetComponent<Move>();
    }
    public override void DeleteCommandFromSequence(Transform slot, Transform Command)
    {
        SimpleDrop drop = slot.GetComponent<SimpleDrop>();
        LevelController.Instance.playerGridController.playerMoveSequences[drop.id] = Command.GetComponent<Move>();
        drop.currentDrag = null;
        Destroy(Command.gameObject);

    }
}
