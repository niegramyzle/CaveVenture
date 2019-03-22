using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInputController : MonoBehaviour
{
    [SerializeField]
    private string horizonInputName;
    [SerializeField]
    private string vertiInputName;
    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private KeyCode jumpKey;
    [SerializeField]
    private bool isJumping;
    [SerializeField]
    private AnimationCurve jumpFallOff;
    [SerializeField]
    private float jumpMultiplier;

    private float horizInput;
    private float vertiInput;

    private void jumpInput()
    {
        if(Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(playerMovement.jumpEvent(jumpMultiplier, jumpFallOff));
        }
    }

    public void setJumping(bool jump)
    {
        isJumping = jump;
    }
    // Update is called once per frame
    void Update()
    {
        horizInput = Input.GetAxis(horizonInputName) * movementSpeed;
        vertiInput = Input.GetAxis(vertiInputName) * movementSpeed;
        playerMovement.playerMovement(horizInput, vertiInput);
        jumpInput();
    }
}
