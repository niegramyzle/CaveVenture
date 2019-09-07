using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GateCon : MonoBehaviour, IOpenable
{
    [SerializeField] private float animationDuration;
    [SerializeField] private float targetVal;
    private Tween gateAnimation;
    private bool isOpen = false;

    public void OpenOnce()
    {
        Debug.Log("AAA");
        if(!isOpen)
        {
            isOpen = true;
            gateAnimation = transform.DOMoveY(targetVal,animationDuration);
        }
    }
}
