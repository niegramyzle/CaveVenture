using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<ContactAgressiveArea>().hit();
    }
}
