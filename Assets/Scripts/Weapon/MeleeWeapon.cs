using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] private Animation animat;
    [SerializeField] private AnimationClip clip;

    public override void hit()
    {
        if(Time.time-previousHitTime>=cooldown)
        {
            onHit = true;
            //Debug.Log("XDD");
            previousHitTime = Time.time;
            //delay/animacja uderzenia
            animat.Play(clip.name);
            StartCoroutine(makeHit());
            //Debug.Log(" NOT XDD");
        }
        //throw new System.NotImplementedException();
    }

    private IEnumerator makeHit()
    {
        Debug.Log("kaj ta animacja");
        do
        {
            yield return null;
        } while (animat.isPlaying);
        onHit = false;
    }
}
