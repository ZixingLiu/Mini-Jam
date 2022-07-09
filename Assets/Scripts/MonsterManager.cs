using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{

    public List<GameObject> Monster = new List<GameObject>();

    public GameObject MonsterHolder;
    // Start is called before the first frame update
    void Start()
    {
        MonsterHolder = GameObject.Find("Monster Holder");

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
            Monster[i].transform.SetParent(MonsterHolder.transform);

           
        }
    }
}
