using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField]
    private string attackKey;
    private CombatController combatCon;
    // Start is called before the first frame update
    void Start()
    {
        combatCon = GetComponent<CombatController>();
    }

    // Update is called once per frame
    void Update()
    {
        //raycast from camera
        if(Input.GetKey(attackKey))
        {
            //combatCon.Attack();
        }

    }


}
