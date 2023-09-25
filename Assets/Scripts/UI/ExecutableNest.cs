using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExecutableNest : ExecutableComponent, IDropHandler
{
    public Transform commandParent;
    public ExecutableComponent childExecutable;
    public TMP_InputField loopingValInputField;
    // Start is called before the first frame update

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.transform.CompareTag("Drag"))  // droping elemnt is Drag i.e.Command
        {
            DraggableComponent draggable = eventData.pointerDrag.GetComponent<DraggableComponent>();
            if (draggable != null && draggable.transform.parent != transform)
                LevelController.Instance.executableContainer.AddCommandToSequence(transform, draggable.transform);
        }
    }
    public void OnLoopingValueChanged(string str)
    {
        int val;
        if (!int.TryParse(str, out val))
        {
            loopingValInputField.text = 0.ToString();
            val = 0;
        }
        GetComponent<NestedMove>().loopingVal = val;
    }

    public void SetChildCommand(ExecutableComponent executable)
    {
        executable.transform.SetParent(commandParent);
        executable.transform.localScale = Vector3.one;
        childExecutable = executable;
        GetComponent<NestedMove>().childMove = executable.GetComponent<Move>();
    }
}
