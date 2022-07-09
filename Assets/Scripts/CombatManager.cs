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

    // Start is called before the first frame update
    void Start()
    {
        attackButton = GameObject.Find("Attack Button").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickAttack()
    {
        //discable button
        attackButton.interactable = false;

        GameObject player = GameObject.Find("Player Slot Holder");

        for(int i=0;i<player.transform.childCount;i++)
        {
            cards.Add( player.transform.GetChild(i).GetChild(0).GetComponent<Cards>());
        }

        StartCoroutine(Attack());

    }

    public IEnumerator Attack()
    {
        for(int i =0;i<cards.Count;i++)
        {
            //move attack
           
            yield return new WaitForSeconds(Time);

        }

    }

    

}
