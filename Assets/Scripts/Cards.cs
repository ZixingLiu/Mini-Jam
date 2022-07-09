using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cards : MonoBehaviour, IPointerDownHandler,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    public float maxHealth;
    public float currentHealth;

    private CanvasGroup canvasGroup;
    private GameObject CardInSceneHolder;
    private GameObject Hand;
    private DoTweenManager doTweenManager;

    public  Vector2 originTransfrom;

    public Canvas canvas;

    public GameObject cardInSceneHolder;

    public bool canDrag = true;

    public GameObject TargetMonster;

    private bool endDrag = false;

    // Start is called before the first frame update
    void Start()
    {
        cardInSceneHolder = GameObject.Find("Card in Scene");
        doTweenManager = GetComponent<DoTweenManager>();

        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        cardInSceneHolder = GameObject.Find("Card in Scene");
        Hand = GameObject.Find("Hand");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            AttackCheck();
        }
    }

    public void AttackCheck()
    {

        Vector2 shootPos = transform.position + Vector3.up * 3;
        RaycastHit2D hit = Physics2D.Raycast(shootPos, Vector2.up, 5);
        Debug.DrawRay(shootPos,Vector2.up, Color.blue, 5);

        if (hit.collider != null)
        {
            //Debug.Log(hit.collider.tag);
            //Debug.Log("check");
            if (hit.collider.tag == "Monster")
            {
                TargetMonster = hit.collider.gameObject;
                PlayAttackAnimation();
            }

        }
    }


    public void PlayAttackAnimation()
    {
        doTweenManager.targetPos = TargetMonster.transform.position;
        doTweenManager.PlayAnimatetion();
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

            endDrag = false;
        }
        

    }

    

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1;

        if(canDrag)
        {
            transform.SetParent(Hand.transform);

            endDrag = true;
        }
    }

    private void OnMouseEnter()
    {
        if(canDrag)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1);
            endDrag = false;

        }
    }

    private void OnMouseExit()
    {
        if(canDrag && !endDrag)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1);

        }
    }
}
