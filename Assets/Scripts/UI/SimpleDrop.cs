using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SimpleDrop : MonoBehaviour, IDropHandler
{
    public SimpleDrag currentDrag;
    public int id;
    public void OnDrop(PointerEventData eventData)
    {
        if (currentDrag == null && eventData.pointerDrag.transform.CompareTag("Drag"))  //if no current Command in slot and droping elemnt is Drag i.e.Command
        {
            SimpleDrag draggable = eventData.pointerDrag.GetComponent<SimpleDrag>();
            if (draggable != null)
            {
                if (!draggable.transform.parent.CompareTag("Slot"))
                {
                    LevelController.Instance.executableContainer.AddCommandToSequence(transform, draggable.transform);
                }
            }
        }
    }

}
