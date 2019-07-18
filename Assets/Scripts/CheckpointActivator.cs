using System;
using UnityEngine;

public class CheckpointActivator : MonoBehaviour
{
    public Action<Transform> ChangeCheckpoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == PlayerManager.instance.Player)
        {
            ChangeCheckpoint(transform);
        }
    }
}
