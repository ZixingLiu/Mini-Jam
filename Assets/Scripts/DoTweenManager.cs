using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenManager : MonoBehaviour
{
    public Vector3 targetPos = Vector3.zero;

    public float duration = 1;

    public Ease moveEase = Ease.Linear;

    public enum DotweenType
    {
        moveOneway,moveTwoway
    }
    public DotweenType dotweenYpe = DotweenType.moveOneway;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            PlayAnimatetion();
        }
    }

    public void PlayAnimatetion()
    {
        if (dotweenYpe == DotweenType.moveOneway)
        {
            if (targetPos == Vector3.zero)
            {
                targetPos = this.transform.position;
            }

            this.transform.DOMove(targetPos, duration).SetEase(moveEase);
        }
        else if (dotweenYpe == DotweenType.moveTwoway)
        {
            if (targetPos == Vector3.zero)
            {
                targetPos = this.transform.position;
            }

            StartCoroutine(moveWithBothWay());
        }
    }


   

    private IEnumerator moveWithBothWay()
    {
        Vector3 orginalPos = this.transform.position;
        this.transform.DOMove(targetPos,duration).SetEase(moveEase);
        yield return new WaitForSeconds(duration);
        this.transform.DOMove(orginalPos,duration).SetEase(moveEase);
    }

    
}
