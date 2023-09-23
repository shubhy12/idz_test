using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SimpleDrag : DraggableComponent
{



    public override void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("On end drag Eventdata " + eventData);
        if (transform.parent.CompareTag("Slot"))    //if inside slot
        {
            if (!eventData.pointerEnter.Equals(transform.parent.gameObject))        //if not drop at current slot i.e. drop outside current slot
            {
                LevelController.Instance.executableContainer.DeleteCommandFromSequence(transform.parent, transform);
                return;
            }
        }

        transform.position = startPosition;
        dragImage.raycastTarget = true;



    }
}
