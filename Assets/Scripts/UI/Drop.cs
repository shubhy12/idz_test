using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drop : MonoBehaviour, IDropHandler
{
    public Drag currentDrag;
    public int id;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop " + eventData + " tag " + eventData.pointerDrag.transform.tag);
        if (currentDrag == null && eventData.pointerDrag.transform.CompareTag("Drag"))  //if no current Command in slot and droping elemnt is Drag i.e.Command
        {
            Drag draggable = eventData.pointerDrag.GetComponent<Drag>();
            Debug.Log("draggable " + draggable);
            if (draggable != null)
            {
                if (!draggable.transform.parent.CompareTag("Slot"))
                {
                    LevelController.Instance.executableContainer.AddCommandToSequence(this, draggable);
                }
            }
        }
    }

}
