using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class BodyParts : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    public enum BodyType { arm, leg, head}
    public BodyType currentType;

    public GameObject currentHolder;
    GameObject cardInSceneHolder;
    CanvasGroup canvasGroup;

    public bool moveBack = true;

    // Start is called before the first frame update
    void Start()
    {
        cardInSceneHolder = GameObject.Find("Card in Scene");
        canvasGroup = GetComponent<CanvasGroup>();

        currentHolder = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentType == BodyType.arm)
        {

        }
    }

    

    

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;

        moveBack = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        transform.SetParent(cardInSceneHolder.transform);

        transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1;

        if (moveBack)
        {
            transform.SetParent(currentHolder.transform);

        }
    }
}
