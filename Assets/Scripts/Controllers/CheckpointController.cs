using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    [SerializeField] List<GameObject> checkpoints;
    public Vector3 CurrentCheckpoint { get; set; }

    void Start()
    {
        foreach(var element in checkpoints )
        {
            element.GetComponent<CheckpointActivator>().ChangeCheckpoint += SetCurrentCheckpoint;
        }
        CurrentCheckpoint = checkpoints[0].transform.position;
    }

     public void SetCurrentCheckpoint(Transform tran)
    {
        CurrentCheckpoint = tran.position;
    }
}
