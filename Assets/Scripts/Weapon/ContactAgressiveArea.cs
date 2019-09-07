using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactAgressiveArea : Weapon
{
    public override void hit()
    {
        if (Time.time - previousHitTime >= cooldown)
        {
            onHit = true;
            previousHitTime = Time.time;
           // StartCoroutine(makeHit());
        }
    }
    //private IEnumerator makeHit()
    //{
    //    yield return null;
    //    onHit = false;
    //}
}
