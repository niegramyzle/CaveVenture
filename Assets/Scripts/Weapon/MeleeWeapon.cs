using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    private Animator anim;

    private void Awake()
    {
        anim =transform.parent.GetComponent<Animator>();
    }

    public override void hit()
    {
        if(Time.time-previousHitTime>=cooldown) //zmienić
        {
            onHit = true;
            Debug.Log("XDD");
            previousHitTime = Time.time;
            anim.SetTrigger("toActive");
            StartCoroutine(makeHit());
            //Debug.Log(" NOT XDD");
        }
        //throw new System.NotImplementedException();
    }

    private IEnumerator makeHit()
    {
        do
        {
            yield return null;
        } while (anim.GetCurrentAnimatorStateInfo(0).normalizedTime>=1);//animat.isPlaying
        anim.SetTrigger("toActive");
        onHit = false;
    }
}
