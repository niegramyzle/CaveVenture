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
            var anim = gameObject.GetComponent<Animator>();
            anim.Rebind();
            anim.enabled = false;
            transform.parent.gameObject.SetActive(false);
        }
    }
}
