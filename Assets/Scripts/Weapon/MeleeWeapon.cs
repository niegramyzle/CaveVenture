using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{

    public override void hit()
    {
        if (!hitTimeFlag)
        {
            hitTimeFlag = true;
            onHit = true;
            if(anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
                anim.SetBool("attack", true);
            StartCoroutine(makeHit());
        }
    }

    private IEnumerator makeHit()
    {
        do
        {
            yield return null;
        } while (anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1f);
        anim.SetBool("attack", false);
        onHit = false;
        hitTimeFlag = false;
    }
}
