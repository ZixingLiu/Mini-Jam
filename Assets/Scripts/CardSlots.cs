using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSlots : MonoBehaviour, IDropHandler
{
    private RectTransform myrRectTransform;

    public bool canPut = true;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("on drop");

        if(canPut)
        {
            if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<Cards>().canDrag)
            {
                eventData.pointerDrag.transform.SetParent(this.transform);
                eventData.pointerDrag.transform.position = transform.position;
                eventData.pointerDrag.GetComponent<Cards>().canDrag = false;

                eventData.pointerDrag.GetComponent<BoxCollider2D>().enabled = false;
                canPut = false;
            }
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        myrRectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

}
