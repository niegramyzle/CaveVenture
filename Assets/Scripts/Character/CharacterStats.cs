using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    [SerializeField] private int health;
    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public bool IsDied { get; set; }

}
