using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Cards : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    [Header("health")]
    public float maxHealth = 100, currentHealth;
    public Image healthBar;
    public TextMeshProUGUI healthText;
    float lerpSpeed;

    [Header("attack")]
    public float damage = 5;
    public TextMeshProUGUI attackText;

     CanvasGroup canvasGroup;
     GameObject Hand;
     DoTweenManager doTweenManager;

    public  Vector2 originTransfrom;


    public GameObject cardInSceneHolder;

    public bool canDrag = true;

    public GameObject TargetMonster;

     bool endDrag = false;
    CombatManager combatManager;
    CardsManager cardsManager;

    public bool canInteract = true;

    private void Awake()
    {
        cardsManager = FindObjectOfType<CardsManager>();
        cardsManager.canPlace = true;

        canDrag = true;
        canInteract = true;

        cardInSceneHolder = GameObject.Find("Card in Scene");
        doTweenManager = GetComponent<DoTweenManager>();

        canvasGroup = GetComponent<CanvasGroup>();

        Hand = GameObject.Find("Hand");
        combatManager = FindObjectOfType<CombatManager>();


        
    }



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        doTweenManager.dotweenType = DoTweenManager.DotweenType.moveTwoway;
    }

    // Update is called once per frame
    void Update()
    {
        combatManager = FindObjectOfType<CombatManager>();
        cardInSceneHolder = GameObject.Find("Card in Scene");
        Hand = GameObject.Find("Hand");
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    AttackCheck();
        //}

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            currentHealth = 0;

            combatManager.cards.Remove(this);
            cardsManager.cards.Remove(this);
            Destroy(gameObject, 1);
        }

        if(damage <= 0)
        {
            damage = 0;
        }
        
        attackText.text = damage.ToString();
        healthText.text = currentHealth + "/" + maxHealth;

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
        ColorChanger();
    }

     void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, currentHealth / maxHealth,lerpSpeed);
    }

    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (currentHealth / maxHealth));

        healthBar.color = healthColor;
    }

    public void TakeDamage(float damage)
    {
        if(currentHealth > 0)
        {
            currentHealth -= damage;
        }
    }

    public void Heal(float healing)
    {
        if(currentHealth <maxHealth)
        {
            currentHealth += healing;
        }
    }

    public void GetBodyPart(float damageChange,float healthChange)
    {
        damage += damageChange;
        maxHealth += healthChange;
        currentHealth += healthChange;

    }

    public void LossBodyPart(float damageChange, float healthChange)
    {
        damage -= damageChange;
        maxHealth -= healthChange;
        currentHealth -= healthChange;

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
                TargetMonster.GetComponent<Monsters>().TakeDamage(damage);

                PlayAttackAnimation();
            }

        }
        else
        {
            if (combatManager.monsters.Count > 0)
            {
                TargetMonster = combatManager.monsters[Random.Range(0, combatManager.monsters.Count)].gameObject;
                TargetMonster.GetComponent<Monsters>().TakeDamage(damage);

                PlayAttackAnimation();
            }

        }
    }


    public void PlayAttackAnimation()
    {
        doTweenManager.targetPos = TargetMonster.transform.position;
        doTweenManager.PlayAnimatetion();
    }


    

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("on drag");
        if(canDrag && canInteract)
        {
            //rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            transform.SetParent(cardInSceneHolder.transform);

            transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(canDrag && canInteract)
        {
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0.6f;

            endDrag = false;
        }
        

    }

    

    public void OnEndDrag(PointerEventData eventData)
    {
        if(canInteract)
        {
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1;

            if (canDrag)
            {
                transform.SetParent(Hand.transform);

                endDrag = true;
            }
        }
        
    }

    private void OnMouseEnter()
    {
        if(canDrag && canInteract)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f);
            endDrag = false;

        }
    }

    private void OnMouseExit()
    {
        if(canDrag && !endDrag && canInteract)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.3f);

        }
    }
}
