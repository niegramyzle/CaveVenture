using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{

    public override void hit()
    {
        if(!hitTimeFlag)
        {
            hitTimeFlag = true;
            onHit = true;
            endAnimFlag = false;
            Debug.Log("trr");
            anim.SetBool("attack", true);
            StartCoroutine(makeHit());
        }
    }

    private IEnumerator makeHit()
    {
        do
        {
            Debug.Log("korr");
            yield return null;
        } while (!endAnimFlag);
        anim.SetBool("attack", false);
        Debug.Log("fal");
        onHit = false;
        hitTimeFlag = false;
    }
}
