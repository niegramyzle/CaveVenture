using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected int damage;
    [SerializeField] protected float cooldown;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float previousHitTime;
    protected bool onHit;
    [SerializeField] private GameObject parent;
    protected bool hitTimeFlag;
    protected bool endAnimFlag;

    public abstract void hit();

    public void endAnim()
    {
        Debug.Log("XDDDDDDDDDDDDD");
        endAnimFlag = true;
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("trrr");
        if (onHit && parent!=other.gameObject)
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
}
