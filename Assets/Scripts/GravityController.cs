using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    [SerializeField] private float gravityMultiplier = -1;
    private CharacterMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = PlayerManager.instance.Player.GetComponent<CharacterMovement>();
    }

    private void OnTriggerStay(Collider other)
    {
        playerMovement.gravityMultiplier = gravityMultiplier;
    }

    private void OnTriggerExit(Collider other)
    {
        playerMovement.gravityMultiplier = 1;
    }
}
