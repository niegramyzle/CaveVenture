using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attach : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private Vector3 oldPos;

    private void Update()
    {
        var aa = player.GetComponent<CharacterMovement>();
        aa.Offset = transform.position - oldPos;
        oldPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            var anim = GetComponent<Animator>().targetPosition;
            Debug.Log("OOOO");
            //player.transform.parent = transform;
            player.SetParent(transform, true);
            var aa = player.GetComponent<CharacterMovement>();
            aa.OnPlatform = true;
            oldPos = transform.position;
        }
    }
    //        player.SetParent(ledge.transform.parent, false); dobry feature XD
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("exx");
        if (other.gameObject == player.gameObject)
        {
            player.GetComponent<CharacterMovement>().OnPlatform = false;
            player.transform.parent = null;
            // player.SetParent(null);
        }
    }
}
