using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;


public class BodyParts : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    AudioSource audioSource;
    public AudioClip tearingSound;

    public bool canInteract = true;

    public enum BodyType { arm, leg, head}
    public BodyType currentType;

    public GameObject currentHolder;
    GameObject cardInSceneHolder;
    CanvasGroup canvasGroup;

    public Cards currentCard;

    public bool moveBack = true;

    [Header("data")]
    public float healthChange;
    public float damageChange;

    [Header("Text")]
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI healthText;

    private void Awake()
    {
        cardInSceneHolder = GameObject.Find("Card in Scene");
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        canvasGroup = GetComponent<CanvasGroup>();

        currentHolder = transform.parent.gameObject;

        currentCard = transform.GetComponentInParent<Cards>();
    }

    // Update is called once per frame
    void Update()
    {
        cardInSceneHolder = GameObject.Find("Card in Scene");
        damageText.text = damageChange.ToString();
        healthText.text = healthChange.ToString();


    }

    
    
    

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(canInteract)
        {
            //Tearing 
            GetComponent<AudioSource>().clip = tearingSound;
            GetComponent<AudioSource>().Play();
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0.6f;

            moveBack = true;
        }
 
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canInteract)
        {
            //rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            transform.SetParent(cardInSceneHolder.transform);

            transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        }
            
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (canInteract)
        {
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1;

            if (moveBack)
            {
                transform.SetParent(currentHolder.transform);

            }
        }
            
    }
}
