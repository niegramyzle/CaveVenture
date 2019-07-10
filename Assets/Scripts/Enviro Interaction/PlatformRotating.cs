using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotating : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Transform transformObject;
    [SerializeField] private float timeLimit;

    private float startTime;
    private InteractionInputController player;
    [SerializeField]private Animator anim;

    private void Start()
    {
        player = PlayerManager.instance.Player.GetComponent<InteractionInputController>();
        //anim = GetComponent<Animator>();
        anim.speed = 0;
    }

    private IEnumerator doRotation()
    {
        float time;
        startTime = Time.time;
        do
        {
            Quaternion quaternionToRotate = Quaternion.FromToRotation(transformObject.forward, transformObject.up) * transformObject.rotation;
            Quaternion quater = Quaternion.Slerp(transformObject.rotation, quaternionToRotate, rotateSpeed * Time.deltaTime);
            transformObject.rotation = quater;
            time = Time.time;
            time -= startTime;
        yield return null;
        } while (time<timeLimit);
    }

    private void OnTriggerStay(Collider other)
    {
        if (player.OnClickInteraction())
        {
            anim.speed = 1;
            StartCoroutine(doRotation());
        }
        else
        {
            anim.speed = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        anim.speed = 0;
    }
}
