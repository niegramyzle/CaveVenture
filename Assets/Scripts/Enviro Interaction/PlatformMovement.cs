using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float duration=3;
    [SerializeField] private float endValue=8;
    private Tween currentAnimation;
    private bool animationState = false;
    private bool animationStart = true;

    private void DoAnimation()
    {
        currentAnimation.Kill();
        float targetVal = animationState ? 0 : endValue;
        currentAnimation = transform.DOLocalMoveZ(targetVal, duration).OnComplete(ChangeState);
    }
    
    private void ChangeState()
    {
        animationState = !animationState;
        animationStart = true;
    }

    void Update()
    {
        if(animationStart)
        {
            animationStart = false;
            DoAnimation();
        }
    }
}
