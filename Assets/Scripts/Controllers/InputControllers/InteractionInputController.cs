using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractionInputController : MonoBehaviour
{
    [SerializeField] private string interactionKeyName;
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode left;

    public bool OnClickInteraction()
    {
        Debug.Log("Press " + interactionKeyName);
        return Input.GetKey(interactionKeyName);
    }

    public bool OnUpClick()
    {
        return Input.GetKeyUp(interactionKeyName);
    }

    public bool OnLeft()
    {
        return Input.GetKey(left);
    }

    public bool OnRight()
    {
        return Input.GetKey(right);
    }

    public bool OnEscape()
    {
        return Input.GetKeyDown(KeyCode.Escape);
    }

    public bool OnLeftEnd()
    {
        return Input.GetKeyUp(left);
    }

    public bool OnRightEnd()
    {
        return Input.GetKeyUp(right);
    }
}
