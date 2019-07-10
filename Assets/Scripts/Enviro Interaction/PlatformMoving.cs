using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private Animator animTrigger;
    private InteractionInputController player;

    private void Start()
    {
        animTrigger = GetComponent<Animator>();
        animTrigger.speed = 0;
        anim.speed = 0;
        player = PlayerManager.instance.Player.GetComponent<InteractionInputController>();
    }

    public void endAnimation()
    {
        animTrigger.speed = 0;
    }

    private void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            anim.speed= 0;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (player.OnClickInteraction())
        {
            animTrigger.speed = 1;
            anim.speed = 1;
        }
    }
}
