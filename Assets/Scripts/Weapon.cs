using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private int damage;

    public int Damage
    {
        get;
        set;
    }
}
