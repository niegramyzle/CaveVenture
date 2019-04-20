using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInputController : MonoBehaviour
{
    [SerializeField]
    private string horizonInputName;//sideway
    [SerializeField]
    private string vertiInputName;//forward
    [SerializeField]
    private KeyCode jumpKey;
    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    float superSpeedTimeLimit;


    float firstTimeClickKey;
    bool doubleClickW;
    bool isAcceleration;
    private bool isJumping;

    private void doubleSpeed()
    {
        if(Input.GetKeyDown("w"))
        {
            if(Time.time-firstTimeClickKey<superSpeedTimeLimit && doubleClickW)
            {
                isAcceleration = true;
                doubleClickW = false;
            }
            else
            {
                firstTimeClickKey = Time.time;
                doubleClickW = true;
            }
        }
        else if(Input.GetKeyUp("w"))
        {
            isAcceleration = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(jumpKey))
        {
            isJumping = true;
        }
        doubleSpeed();
        playerMovement.playerMovement(Input.GetAxis(horizonInputName), Input.GetAxis(vertiInputName), isJumping, isAcceleration);
        isJumping = false;
    }
}