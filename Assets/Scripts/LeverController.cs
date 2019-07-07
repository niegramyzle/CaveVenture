using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LeverController : MonoBehaviour, IInteractableObject
{
    [SerializeField] private Transform leverArm;
    [SerializeField] private Vector3 offRotation; 
    [SerializeField] private Vector3 onRotation;
    [SerializeField] private float animationDuration;
    private bool currentMovementState = false;
    private bool leverLogicState = false;
    private Tween currentAnimation;

    public bool getLeverLogicState() 
    { 
        return this.leverLogicState;  
    }
    public void OnObjectClick()
    {
        currentMovementState = !currentMovementState;

        currentAnimation.Kill();

        Vector3 direction = currentMovementState ? onRotation : offRotation;

        currentAnimation = leverArm.DOLocalRotate(direction, animationDuration).OnComplete(UpdateLogicState);
    }

    private void UpdateLogicState()
    {
        leverLogicState = currentMovementState;
    }
}
