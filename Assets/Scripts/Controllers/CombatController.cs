using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    CharacterStats stats;
    private void Awake()
    {
        stats = GetComponent<CharacterStats>();
    }

    public void takeDamage(int dmg)
    {
        Debug.Log(stats.Health);
        stats.Health -= dmg;
        if (stats.Health <= 0)
            stats.IsDied = true;
    }
}
