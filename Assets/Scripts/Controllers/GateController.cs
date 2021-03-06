﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GateController : MonoBehaviour
{
    [SerializeField] private List<GameObject> cubes;
    [SerializeField] private List<GameObject> placesForCubes;
    [SerializeField] private InteractionInputController player;
    private Animator anim;
    private int placeIndex;
    private bool isReady;
    private string text="get a cube.";

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.speed = 0;
    }

    public void endAnimHandler()
    {
        anim.speed = 0;
    }

    private void addCube()
    {
        var element = cubes.Find(cube => !cube.activeSelf);
        if (element != null)
        {
            Debug.Log("TTTTTTTTTT");
            element.transform.position = placesForCubes[placeIndex].transform.position;
            element.transform.rotation = placesForCubes[placeIndex].transform.rotation;
            element.transform.SetParent(placesForCubes[placeIndex].transform, true);
            element.SetActive(true);
            placeIndex++;
        }
        isReadyToOpen();
    }

    private void isReadyToOpen()
    {
        if (placeIndex == cubes.Capacity)
        {
            text = "open a gate.";
            isReady = true;
        }
    }

    private void openGate()
    {
        anim.speed = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == PlayerManager.instance.Player)
            CommunicateManager.instance.ShowMessageOnUI("Press F to "+ text);
    }

    private void OnTriggerExit(Collider other)
    {
        CommunicateManager.instance.ResetText();
    }


    private void OnTriggerStay(Collider other)
    {
        if (player.OnClickInteraction())
        {
            if (!isReady)
            {
                addCube();
            }
            else if (isReady)
            {
                openGate();
                gameObject.GetComponent<Collider>().enabled = false;
            }
        }
    }


}
