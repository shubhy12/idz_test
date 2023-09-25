using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExecutableLoopingContainer : ExecutableCommandContainer, IDropHandler
{
    public List<ExecutableComponent> executablesList = new List<ExecutableComponent>();

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.transform.CompareTag("Drag"))  //droping elemnt is Drag i.e.Command
        {
            DraggableComponent draggable = eventData.pointerDrag.GetComponent<DraggableComponent>();
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
        LoopingDraggable loopingDraggable = command.GetComponent<LoopingDraggable>();
        if (loopingDraggable?.executable == null) return;
        ExecutableComponent newExecutable = Instantiate(loopingDraggable.executable);

        if (slot != transform)
        {
            slot.GetComponent<ExecutableNest>()?.SetChildCommand(newExecutable);
        }
        else
        {
            newExecutable.transform.SetParent(slot);
            newExecutable.transform.SetAsLastSibling();
            newExecutable.transform.localScale = Vector3.one;
            executablesList.Add(newExecutable);
            LevelController.Instance.playerGridController.playerMoveSequences.Add(newExecutable.GetComponent<Move>());
        }

    }
    public override void DeleteCommandFromSequence(Transform slot, Transform command)
    {
        if (slot != transform)
        {
            ExecutableNest executableNest = slot.GetComponent<ExecutableNest>();
            if (executableNest == null) return;
            executableNest.childExecutable = null;
            executableNest.GetComponent<NestedMove>().childMove = null;
        }
        else
        {
            ExecutableComponent executable = command.GetComponent<ExecutableComponent>();
            if (executable == null) return;
            LevelController.Instance.playerGridController.playerMoveSequences.Remove(executable.GetComponent<Move>());
            executablesList.Remove(executable);
        }
        Destroy(command.gameObject);
    }
}
