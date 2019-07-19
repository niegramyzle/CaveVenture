using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected int damage;
    [SerializeField] protected float cooldown;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float previousHitTime;
    [SerializeField] private GameObject generalParent;
    protected Animator anim;
    protected bool onHit;
    protected bool hitTimeFlag;
    protected bool endAnimFlag;

    public abstract void hit();

    private void Awake()
    {
        
        anim = transform.GetComponent<Animator>();
    }

    public void endAnim()
    {
        endAnimFlag = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (onHit && generalParent!=other.gameObject)
        {
            CombatController target = other.gameObject.GetComponent<CombatController>();
            if (target != null)
            {
                target.takeDamage(damage);
                onHit = false;
            }
        }
    }
}
