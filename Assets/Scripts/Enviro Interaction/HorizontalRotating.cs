using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class HorizontalRotating : MonoBehaviour
{
    private GameObject player;
    private InteractionInputController interaction;

    Quaternion quatToRotate;
    Quaternion quater;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float timeLimit;
    private float startTime;

    private Tween currentAnimation;
    [SerializeField] private float duringAnimation = 0.2f;
    [SerializeField] private float speed = 1f;

    public Action updateDependentMethod;

    void Start()
    {
        player=PlayerManager.instance.Player.gameObject;
        interaction = player.GetComponent<InteractionInputController>();
    }

    private IEnumerator doRotation(int direction)
    {
        float time;
        startTime = Time.time;
        do
        {
            quatToRotate = Quaternion.FromToRotation(transform.right*direction, transform.up) * transform.rotation;
            quater = Quaternion.Slerp(transform.rotation, quatToRotate, rotateSpeed * Time.deltaTime);
            transform.rotation = quater;
            time = Time.time;
            time -= startTime;
            yield return null;
        } while (time<timeLimit);
    }

    private void rotat(int direction)
    {
        currentAnimation.Kill();
        currentAnimation = transform.DORotate(transform.rotation.eulerAngles+ Vector3.up*direction*speed, duringAnimation);
    }

    private void OnTriggerStay(Collider other)
    {

        if (interaction.OnLeft())
        {
            updateDependentMethod();
           // StartCoroutine(doRotation(-1));
            rotat(-1);
        } 
        else if(interaction.OnRight())
        {

            updateDependentMethod();
          //  StartCoroutine(doRotation(1));
            rotat(1);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        CommunicateManager.instance.ShowMessageOnUI("Press left(Q) or right(E) key to rotate.");
    }

    private void OnTriggerExit(Collider other)
    {
        CommunicateManager.instance.ResetText();
    }
}
