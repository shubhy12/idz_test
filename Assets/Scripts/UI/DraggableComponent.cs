using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableComponent : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Image dragImage;
    public Vector3 startPosition;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }



    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        dragImage.raycastTarget = false;
    }
    public virtual void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }


    public virtual void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("On end drag Eventdata " + eventData);

        transform.position = startPosition;
        dragImage.raycastTarget = true;


    }
}
