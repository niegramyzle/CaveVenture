using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private CheckpointController currentCheckpoint;
    private CharacterStats playerStats;

    private void Start()
    {
        currentCheckpoint = GetComponent<CheckpointController>();
        playerStats=PlayerManager.instance.Player.GetComponent<CharacterStats>();
    }
    
    private bool isPlayerDead()
    {
        return playerStats.IsDied;
    }

    private void respawnPlayer()
    {
        PlayerManager.instance.Player.GetComponent<CharacterController>().enabled = false;
        PlayerManager.instance.Player.transform.position=currentCheckpoint.CurrentCheckpoint;
        PlayerManager.instance.Player.GetComponent<CharacterController>().enabled = true;
        playerStats.resetStats();
    }

    void Update()
    {
        if (isPlayerDead())
        {
            respawnPlayer();
        }
    }
}
