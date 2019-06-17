using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractionInputController : MonoBehaviour
{
    [SerializeField] string interactionKeyName;

    public bool OnClickInteraction()
    {
        Debug.Log("Press " + interactionKeyName);
        return Input.GetKey(interactionKeyName);
    }

    public bool OnUpClick()
    {
        return Input.GetKeyUp(interactionKeyName);
    }

}
