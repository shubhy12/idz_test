using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Image dragImage;
    public Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        dragImage = GetComponent<Image>();
        startPosition = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragImage.raycastTarget = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("On end drag Eventdata " + eventData);
        if (transform.parent.CompareTag("Slot"))    //if inside slot
        {
            if (!eventData.pointerEnter.Equals(transform.parent.gameObject))        //if not drop at current slot i.e. drop outside current slot
            {
                LevelController.Instance.executableContainer.DeleteCommandFromSequence(transform.parent.GetComponent<Drop>(), this);
                return;
            }
        }

        transform.position = startPosition;
        dragImage.raycastTarget = true;


    }
}
