﻿using System.Collections;
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
            if (anim != null)
                anim.SetBool("attack", true);
            else
                Debug.Log("AAAAAAAAAAAAAAAAA");
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
