using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    private CombatManager combatManager;

    public List<GameObject> Monster = new List<GameObject>();

    public GameObject MonsterHolder;
    // Start is called before the first frame update
    void Start()
    {
        MonsterHolder = GameObject.Find("Monster Slot Holder");
        combatManager = FindObjectOfType<CombatManager>();

        PutMonsterInSlot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PutMonsterInSlot()
    {
        for (int i = 0; i < Monster.Count; i++)
        {
            if(i< MonsterHolder.transform.childCount)
            {
                Monster[i].transform.SetParent(MonsterHolder.transform.GetChild(i));

                Monster[i].transform.position = MonsterHolder.transform.GetChild(i).position;

                Monster[i].transform.localScale = Vector3.one;

                combatManager.monsters.Add(Monster[i].GetComponent<Monsters>());

            }



        }
    }
}
