using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Reward : MonoBehaviour
{
    CardsManager cardsManager;

    public GameObject newCard;
    StartMenu startMenu;

    // Start is called before the first frame update
    void Start()
    {
        startMenu = GetComponent<StartMenu>();
    }

    private void Awake()
    {
        cardsManager = FindObjectOfType<CardsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddDamage()
    {
        Debug.Log("add damage");

        foreach(Cards cards in cardsManager.cards)
        {
            cards.damage += 1;
        }
        startMenu.StartGame();
    }

    public void GetNewCard()
    {
        if(newCard != null)
        {
            Debug.Log("get new card");
            newCard.SetActive(true);
            newCard.transform.SetParent(cardsManager.transform);
            cardsManager.cards.Add(newCard.GetComponent<Cards>());

            startMenu.StartGame();
        }
    }
}
