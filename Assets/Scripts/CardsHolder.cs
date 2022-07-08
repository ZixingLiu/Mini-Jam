using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsHolder : MonoBehaviour
{

    public List<GameObject> cards = new List<GameObject>();

    public GameObject Hand;

    // Start is called before the first frame update
    void Start()
    {
        Hand = GameObject.Find("Hand");

        PutCardInHand();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PutCardInHand()
    {

        for(int i = 0; i < cards.Count;i++)
        {
            cards[i].transform.SetParent(Hand.transform);
            
            cards[i].GetComponent<Cards>().originTransfrom = cards[i].transform.localPosition;
        }

        
    }

}
