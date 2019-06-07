﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovementInputController : MonoBehaviour
{
    [SerializeField]
    private string horizonInputName;//sideway
    [SerializeField]
    private string vertiInputName;//forward
    [SerializeField]
    private KeyCode jumpKey;
    [SerializeField]
    private CharacterMovement playerMovement;
    [SerializeField]
    float superSpeedTimeLimit;

    public Action speedZoomingOn;
    public Action speedZoomingOff;

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

        if (isAcceleration)
            speedZoomingOn();
        else
            speedZoomingOff();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(jumpKey))
        {
            isJumping = true;
        }
        doubleSpeed();
        playerMovement.movement(Input.GetAxis(horizonInputName), Input.GetAxis(vertiInputName), isJumping, isAcceleration);
        isJumping = false;
    }
}