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

    [SerializeField] private Transform openableObject;
    private IOpenable openable;

    private Action activatingObject=delegate { };
    private void Start()
    {
        if (openableObject != null)
        {
            openable=openableObject.GetComponent<IOpenable>();
            activatingObject += openable.OpenOnce;
        }
    }

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

        activatingObject();
    }

    private void UpdateLogicState()
    {
        leverLogicState = currentMovementState;
    }

    private void OnTriggerEnter(Collider other)
    {
        CommunicateManager.instance.ShowMessageOnUI("Press I key towards lever.");
    }

    private void OnTriggerExit(Collider other)
    {
        CommunicateManager.instance.ResetText();
    }

}
