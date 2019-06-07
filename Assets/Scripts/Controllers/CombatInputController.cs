using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatInputController : MonoBehaviour
{
    [SerializeField]
    private string attackKey;
    private CombatController combatCon;
    private Inventory inv;

    // Start is called before the first frame update
    void Awake()
    {
        combatCon = GetComponent<CombatController>();
        inv = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))//Input.GetKey(attackKey)
        {
           inv.CurrentWeapon.hit();
        }

    }


}
