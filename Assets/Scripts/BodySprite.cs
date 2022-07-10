using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySprite : MonoBehaviour
{
    public GameObject changedBodySprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount <= 0)
        {
            changedBodySprite.SetActive(false);
        }
        else
        {
            changedBodySprite.SetActive(true);
        }
    }
}
