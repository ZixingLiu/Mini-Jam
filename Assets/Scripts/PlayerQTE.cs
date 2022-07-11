using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQTE : MonoBehaviour
{
    GameObject targetBug;

    DoTweenManager doTweenManager;

    public List<GameObject> bugs = new List<GameObject>();

    public GameObject rightTarget;

    public GameObject miniGameCanvas;

    public GameObject AddedMonsterCard;

    MonsterManager monsterManager;
    CardsManager cardsManager;

    public bool finishGame = false;

    private void Awake()
    {
        doTweenManager = GetComponent<DoTweenManager>();

        doTweenManager.targetPos = rightTarget.transform.position;
        doTweenManager.PlayAnimatetion();

        monsterManager = FindObjectOfType<MonsterManager>();
        cardsManager = FindObjectOfType<CardsManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bugs.Count <=0)
        {
            Success();

        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            Success();
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            Fail();
        }
    }

    public void Fail()
    {
        miniGameCanvas.SetActive(false);
        //monster

        finishGame = true;

        AddedMonsterCard.transform.SetParent(monsterManager.transform);
        AddedMonsterCard.SetActive(true);
        monsterManager.Monster.Add(AddedMonsterCard);
        monsterManager.PutMonsterInSlot();

        foreach(Cards card in cardsManager.cards)
        {
            card.canPlaySound = true;
        }

    }

    public void Success()
    {
        finishGame = true;
        miniGameCanvas.SetActive(false);
        monsterManager.PutMonsterInSlot();

        foreach (Cards card in cardsManager.cards)
        {
            card.canPlaySound = true;
        }
    }

    public void ClickHit()
    {
        if(targetBug !=null)
        {
            bugs.Remove(targetBug);
            Destroy(targetBug);
            
        }
        else
        {
            Fail();
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "QTE")
        {
            targetBug = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "QTE")
        {
            targetBug = null;
        }
    }
}
