using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    private List<Weapon> weapons;

    [SerializeField]
    private Weapon currentWeapon;
    public Weapon CurrentWeapon
    {
        get { return currentWeapon; }
        set { currentWeapon = value; }
    }

    private void Awake()
    {
        weapons = new List<Weapon>();
    }

    public void addWeapon(Weapon weapon)
    {
        weapons.Add(weapon);
    }



}
