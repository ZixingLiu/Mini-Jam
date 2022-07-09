using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters : MonoBehaviour
{

    public GameObject TargetPlayer;

    private DoTweenManager doTweenManager;


    // Start is called before the first frame update
    void Start()
    {
        doTweenManager = GetComponent<DoTweenManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            AttackCheck();
        }
    }

    public void AttackCheck()
    {

        Vector2 shootPos = transform.position + Vector3.down * 3;
        RaycastHit2D hit = Physics2D.Raycast(shootPos, Vector2.down, 5);
        Debug.DrawRay(shootPos, Vector2.down, Color.blue, 5);

        if (hit.collider != null)
        {
            //Debug.Log(hit.collider.tag);
            if (hit.collider.tag == "Card")
            {
                TargetPlayer = hit.collider.gameObject;
                PlayAttackAnimation();
            }

        }
    }

    public void PlayAttackAnimation()
    {
        doTweenManager.targetPos = TargetPlayer.transform.position;
        doTweenManager.PlayAnimatetion();
    }
}
