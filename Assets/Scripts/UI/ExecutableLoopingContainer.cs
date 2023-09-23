using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExecutableLoopingContainer : ExecutableCommandContainer, IDropHandler
{
    public List<ExecutableComponent> executablesList = new List<ExecutableComponent>();


    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop " + eventData + " tag " + eventData.pointerDrag.transform.tag);
        if (eventData.pointerDrag.transform.CompareTag("Drag"))  //if no current Command in slot and droping elemnt is Drag i.e.Command
        {
            DraggableComponent draggable = eventData.pointerDrag.GetComponent<DraggableComponent>();
            Debug.Log("draggable " + draggable);
            if (draggable != null)
            {
                if (draggable.transform.parent != transform)
                {
                    AddCommandToSequence(transform, draggable.transform);
                }
            }
        }
    }

    public override void AddCommandToSequence(Transform slot, Transform command)
    {
        Debug.Log("Adding Command " + command.name);
        LoopingDraggable loopingDraggable = command.GetComponent<LoopingDraggable>();
        ExecutableComponent newExecutable = Instantiate(loopingDraggable.executable, transform);
        newExecutable.transform.SetAsFirstSibling();
        executablesList.Add(newExecutable);
        LevelController.Instance.playerGridController.playerMoveSequences.Add(newExecutable.GetComponent<Move>());

    }
    public override void DeleteCommandFromSequence(Transform slot, Transform command)
    {
        LevelController.Instance.playerGridController.playerMoveSequences.Remove(command.GetComponent<Move>());
        executablesList.Remove(command.GetComponent<ExecutableComponent>());
        Destroy(command.gameObject);

    }
}
