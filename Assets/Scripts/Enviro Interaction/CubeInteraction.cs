using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteraction : MonoBehaviour
{
    [SerializeField] GameObject target;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject==target)
        {
            gameObject.SetActive(false);
        }
    }
}
