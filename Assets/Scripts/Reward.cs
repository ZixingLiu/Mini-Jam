using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Reward : MonoBehaviour
{
    public CardsManager cardsManager;

    StartMenu startMenu;

    public GameObject[] newCard;
    GameObject Hand;

    // Start is called before the first frame update
    void Start()
    {
        startMenu = GetComponent<StartMenu>();
        Hand = GameObject.Find("Hand");

    }

    private void Awake()
    {
        cardsManager = FindObjectOfType<CardsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        cardsManager = FindObjectOfType<CardsManager>();
    }

    public void AddDamage()
    {
        Debug.Log("add damage");

        foreach(Cards cards in cardsManager.cards)
        {
            cards.damage += 1;
        }

        for (int i = 0; i < Hand.transform.childCount; i++)
        {
            Hand.transform.GetChild(0).GetComponent<Cards>().canDrag = true;
            Hand.transform.GetChild(0).transform.SetParent(cardsManager.transform);

        }

        StartCoroutine(changeMapScene());
    }

    public void AddHealth()
    {
        Debug.Log("add health");

        foreach (Cards cards in cardsManager.cards)
        {
            cards.currentHealth += 1;
        }
        for (int i = 0; i < Hand.transform.childCount; i++)
        {
            Hand.transform.GetChild(0).GetComponent<Cards>().canDrag = true;
            Hand.transform.GetChild(0).transform.SetParent(cardsManager.transform);

        }

        StartCoroutine(changeMapScene());
    }

    public void GetNewCard(int num)
    {
        if(newCard[num] != null)
        {
            
            Debug.Log("get new card");
            newCard[num].SetActive(true);
            newCard[num].transform.SetParent(cardsManager.gameObject.transform);
            cardsManager.cards.Add(newCard[num].GetComponent<Cards>());

            StartCoroutine(changeMapScene());
        }
    }

    IEnumerator changeMapScene()
    {
        yield return new WaitForSeconds(0.8f);
        startMenu.StartGame();
    }
}
