using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cards : MonoBehaviour, IPointerDownHandler,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public Canvas canvas;

    public GameObject cardInSceneHolder;
    // Start is called before the first frame update
    void Start()
    {
        cardInSceneHolder = GameObject.Find("Card in Scene");
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
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

        Debug.Log("on pointer down");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("on drag");

        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.interactable = true;
        canvasGroup.alpha = 1;
    }
}
