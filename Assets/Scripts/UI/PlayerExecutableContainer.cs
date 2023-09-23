using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExecutableContainer : MonoBehaviour
{
    public Drop[] slots;
    // Start is called before the first frame update
    void Start()
    {
        SetSlotIds();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SetSlotIds()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].id = i;
            LevelController.Instance.playerGridController.playerMoveSequences.Add(null);
        }
    }

    public void AddCommandToSequence(Drop slot, Drag draggableCommand)
    {
        Debug.Log("Adding Command " + draggableCommand.name + " to " + slot.name);
        Drag newDragCommand = Instantiate(draggableCommand, slot.transform);
        slot.currentDrag = newDragCommand;
        newDragCommand.transform.position = newDragCommand.startPosition = slot.transform.position;
        newDragCommand.dragImage.raycastTarget = true;
        LevelController.Instance.playerGridController.playerMoveSequences[slot.id] = draggableCommand.GetComponent<Move>();
    }
    public void DeleteCommandFromSequence(Drop parentSlot, Drag draggableCommand)
    {
        LevelController.Instance.playerGridController.playerMoveSequences[parentSlot.id] = draggableCommand.GetComponent<Move>();
        parentSlot.currentDrag = null;
        Destroy(draggableCommand.gameObject);

    }
}
