using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attach : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private Vector3 oldPos;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            player.GetComponent<CharacterMovement>().Offset = transform.position - oldPos;
            oldPos = transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            player.SetParent(transform, true);
            player.GetComponent<CharacterMovement>().OnPlatform = true;
            player.GetComponent<FirstPersonCamera>().onChangedParent(player.localRotation);
            oldPos = transform.position;
        }
    }
    private void OnTriggerExit(Collider other)
    {
          if (other.gameObject == player.gameObject)
        {
            player.GetComponent<CharacterMovement>().OnPlatform = false;
            player.transform.parent = null;
            player.GetComponent<FirstPersonCamera>().onChangedParent(player.localRotation);

            //player.localRotation = Quaternion.Inverse(transform.rotation) * player.rotation;
        }
    }
}
