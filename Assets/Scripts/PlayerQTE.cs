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

    public bool finishGame = false;

    private void Awake()
    {
        doTweenManager = GetComponent<DoTweenManager>();

        doTweenManager.targetPos = rightTarget.transform.position;
        doTweenManager.PlayAnimatetion();

        monsterManager = FindObjectOfType<MonsterManager>();
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
            finishGame = true;
            miniGameCanvas.SetActive(false);
            monsterManager.PutMonsterInSlot();

        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            finishGame = true;
            miniGameCanvas.SetActive(false);
            monsterManager.PutMonsterInSlot();
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            miniGameCanvas.SetActive(false);
            //monster

            finishGame = true;

            AddedMonsterCard.transform.SetParent(monsterManager.transform);
            AddedMonsterCard.SetActive(true);
            monsterManager.Monster.Add(AddedMonsterCard);
            monsterManager.PutMonsterInSlot();
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
            miniGameCanvas.SetActive(false);
            //monster

            finishGame = true;

            AddedMonsterCard.transform.SetParent(monsterManager.transform);
            AddedMonsterCard.SetActive(true);
            monsterManager.Monster.Add(AddedMonsterCard);
            monsterManager.PutMonsterInSlot();
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
