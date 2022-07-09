using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsManager: MonoBehaviour
{

    public List<Cards> cards = new List<Cards>();

    public GameObject Hand;

    public bool canPlace = true;

    private void Awake()
    {
        int numCardManeger = FindObjectsOfType<CardsManager>().Length;


        if (numCardManeger != 1)
        {
            Destroy(this.gameObject);
            Debug.Log("destroy me");
            return;
        }
        // if more then one music player is in the scene
        //destroy ourselves
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

        Hand = GameObject.Find("Hand");

        canPlace = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        


       
    }

    // Update is called once per frame
    void Update()
    {
        if(canPlace)
        {
            Debug.Log("put card in hand");
            PutCardInHand();
            canPlace = false;
        }
    }

    public void PutCardInHand()
    {

        for(int i = 0; i < cards.Count;i++)
        {
            if(Hand != null)
            {
                cards[i].transform.SetParent(Hand.transform);
                cards[i].transform.localScale = Vector3.one;

                cards[i].GetComponent<Cards>().originTransfrom = cards[i].transform.localPosition;
            }   
        } 
    }

}
