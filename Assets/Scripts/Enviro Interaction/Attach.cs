using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attach : MonoBehaviour
{
    [SerializeField]
    private GameObject character;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == character)
            character.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == character)
            character.transform.parent = null;
    }
}
