using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cards : MonoBehaviour, IPointerDownHandler,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private GameObject CardInSceneHolder;
    private GameObject Hand;

    public  Vector2 originTransfrom;

    public Canvas canvas;

    public GameObject cardInSceneHolder;

    public bool canDrag = true;
    // Start is called before the first frame update
    void Start()
    {
        cardInSceneHolder = GameObject.Find("Card in Scene");
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        cardInSceneHolder = GameObject.Find("Card in Scene");
        Hand = GameObject.Find("Hand");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {

    }


    public void OnPointerDown(PointerEventData eventData)
    {

        //Debug.Log("on pointer down");
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("on drag");
        if(canDrag)
        {
            //rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            transform.SetParent(cardInSceneHolder.transform);

            transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(canDrag)
        {
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0.6f;
        }
        

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1;

        if(canDrag)
        {
            transform.SetParent(Hand.transform);

        }
    }

    private void OnMouseEnter()
    {
        if(canDrag)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1);

        }
    }

    private void OnMouseExit()
    {
        if(canDrag)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1);

        }
    }
}
