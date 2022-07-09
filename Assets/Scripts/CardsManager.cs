using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsManager: MonoBehaviour
{

    public List<Cards> cards = new List<Cards>();

    public GameObject Hand;

    private void Awake()
    {
        int numCardManeger = FindObjectsOfType<CardsManager>().Length;
        if (numCardManeger != 1)
        {
            Destroy(this.gameObject);
        }
        // if more then one music player is in the scene
        //destroy ourselves
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

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
            cards[i].transform.localScale = Vector3.one;
            
            cards[i].GetComponent<Cards>().originTransfrom = cards[i].transform.localPosition;
        }

        
    }

}
