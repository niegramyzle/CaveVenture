using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    private Animator anim;

    private void Awake()
    {
        anim =transform.GetComponent<Animator>();
    }

    public override void hit()
    {
        if(!hitTimeFlag) //Time.time-previousHitTime>=cooldown
        {
            hitTimeFlag = true;
            onHit = true;

            previousHitTime = Time.time;
            Debug.Log("trr");
            anim.SetBool("attack", true);
            endAnimFlag = false;
            StartCoroutine(makeHit());
        }
        //throw new System.NotImplementedException();
    }

    private IEnumerator makeHit()
    {
        do
        {
            Debug.Log("korr");
            yield return null;
        } while (!endAnimFlag);//anim.GetCurrentAnimatorStateInfo(0).normalizedTime>=1
        anim.SetBool("attack", false);
        Debug.Log("fal");
        onHit = false;
        hitTimeFlag = false;
    }
}
