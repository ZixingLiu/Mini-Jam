using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    public Button attackButton;

    public List<Cards> cards = new List<Cards>();

    public List<Monsters> monsters = new List<Monsters>();

    public float Time;

    CardsManager cardsManager;

    GameObject[] allCards;
    GameObject[] allBodyPart;

    // Start is called before the first frame update
    void Start()
    {
        
        attackButton = GameObject.Find("Attack Button").GetComponent<Button>();
        cardsManager = FindObjectOfType<CardsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(monsters.Count <= 0)
        {
            Debug.Log("win fight");
        }

        if(cardsManager.cards.Count <= 0)
        {
            Debug.Log("Player fail");
        }

        allCards = GameObject.FindGameObjectsWithTag("Card");
        allBodyPart = GameObject.FindGameObjectsWithTag("BodyPart");
    }

    public void ClickAttack()
    {
        //discable button
        attackButton.interactable = false;

        GameObject player = GameObject.Find("Player Slot Holder");

        foreach(GameObject card in allCards)
        {
            card.GetComponent<Cards>().canInteract = false;
        }

        foreach(GameObject bodypart in allBodyPart)
        {
            bodypart.GetComponent<BodyParts>().canInteract = false;
        }

        StartCoroutine(Attack());

    }

    public IEnumerator Attack()
    {
        for(int i =0;i<cards.Count;i++)
        {

            cards[i].AttackCheck();

            yield return new WaitForSeconds(Time);


        }

        yield return new WaitForSeconds(0.5f);

        for (int j=0;j<monsters.Count;j++)
        {
            monsters[j].AttackCheck();

            yield return new WaitForSeconds(Time);
        }

        attackButton.interactable = true;

        foreach (GameObject card in allCards)
        {
            card.GetComponent<Cards>().canInteract = true;
        }

        foreach (GameObject bodypart in allBodyPart)
        {
            bodypart.GetComponent<BodyParts>().canInteract = true;
        }

        StopCoroutine(Attack());

    }

    

}
