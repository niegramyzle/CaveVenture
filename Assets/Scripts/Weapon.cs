using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected int damage;
    [SerializeField] protected float cooldown;
    [SerializeField] protected float previousHitTime;
    protected bool onHit;

    public abstract void hit();

    private void OnTriggerStay(Collider other)
    {
        if (onHit && transform.parent.gameObject!=other.gameObject)
        {
            Debug.Log("hit");
            CombatController target = other.gameObject.GetComponent<CombatController>();
            if (target != null)
            {
                Debug.Log(other.gameObject.name);
                target.takeDamage(damage);
                onHit = false;
            }
            else
                Debug.Log("je null");
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (onHit && !other.transform.parent)
    //    {
    //        Debug.Log("hit");
    //        CombatController target = other.gameObject.GetComponent<CombatController>();
    //       // Debug.Log(other.gameObject.name);
    //        if (target != null)
    //        {
    //           // Debug.Log("kolizja z cc");
    //            target.takeDamage(damage);
    //            onHit = false;
    //        }
    //    //Debug.Log("kolizja bez");
    //    }
    //    //Debug.Log("nope");
    //}
}
