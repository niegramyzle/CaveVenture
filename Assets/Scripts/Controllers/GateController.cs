using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GateController : MonoBehaviour
{
    [SerializeField] private List<GameObject> cubes;
    [SerializeField] private List<GameObject> placesForCubes;
    [SerializeField] private InteractionInputController player;
    private int placeIndex;

    private void addCube()
    {
        var element = cubes.Find(cube => !cube.activeSelf);
        if (element!=null)
        {
            Debug.Log("nie powinno");
            element.transform.position = placesForCubes[placeIndex].transform.position;
            element.transform.rotation = placesForCubes[placeIndex].transform.rotation;
            element.SetActive(true);
            placeIndex++;
            }
    }

    private bool isReadyToOpen()
    {
        return true;
    }

    private void openGate()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if(player.OnClickInteraction())
        {
            addCube();
        }
    }


}
