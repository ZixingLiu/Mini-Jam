using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BodySlot : MonoBehaviour,IDropHandler
{
    public Cards currentCharacter;

    public enum BodySlotType { arm, leg, head}
    public BodySlotType currentSlotTpe;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<BodyParts>() != null)
        {
            BodyParts bodyParts = eventData.pointerDrag.GetComponent<BodyParts>();

            if(currentSlotTpe == BodySlotType.arm && bodyParts.currentType == BodyParts.BodyType.arm)
            {
                eventData.pointerDrag.transform.SetParent(this.transform);
                eventData.pointerDrag.transform.position = transform.position;
                bodyParts.moveBack = false;
                bodyParts.currentHolder = this.gameObject;

            }
            else if(currentSlotTpe == BodySlotType.leg && bodyParts.currentType == BodyParts.BodyType.leg)
            {
                eventData.pointerDrag.transform.SetParent(this.transform);
                eventData.pointerDrag.transform.position = transform.position;
                bodyParts.moveBack = false;
                bodyParts.currentHolder = this.gameObject;
            }
            else if(currentSlotTpe == BodySlotType.head && bodyParts.currentType == BodyParts.BodyType.head)
            {
                eventData.pointerDrag.transform.SetParent(this.transform);
                eventData.pointerDrag.transform.position = transform.position;
                bodyParts.moveBack = false;
                bodyParts.currentHolder = this.gameObject;
            }
            

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
