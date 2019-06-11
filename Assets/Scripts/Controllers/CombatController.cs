using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    [SerializeField]
    private int health;
    public int Health
    {
        get { return Health; }
        set { health = value; }
    }
    [SerializeField]
    private float cooldown;
    [SerializeField]
    private float attackSpeed;


    Weapon weapon;
    CharacterStats stats;
    private void Awake()
    {
        stats = GetComponent<CharacterStats>();
    }


    public void takeDamage(int dmg)
    {
        Debug.Log(health);
        health -= dmg;
        if (health == 0)
            stats.IsDied = true;
    }

    public void Attack()
    {
        //CombatController target

        if (cooldown<=0)
        {
            //hit
            cooldown = attackSpeed;
        }
    }

}
