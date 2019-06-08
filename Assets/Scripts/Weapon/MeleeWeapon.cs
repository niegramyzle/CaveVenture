using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    public override void hit()
    {
        if(Time.time-previousHitTime>=cooldown)
        {
            onHit = true;
            //Debug.Log("XDD");
            previousHitTime = Time.time;
            //delay/animacja uderzenia
            StartCoroutine(makeHit());
            //Debug.Log(" NOT XDD");
        }
        //throw new System.NotImplementedException();
    }

    private IEnumerator makeHit()
    {
        yield return new WaitForSeconds(1);
        //Debug.Log(" :>>>");
        onHit = false;
    }
}
