using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    public Button attackButton;

    

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

        
    }

}
