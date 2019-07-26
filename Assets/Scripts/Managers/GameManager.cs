using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    private CheckpointController currentCheckpoint;
    private CharacterStats playerStats;

    [SerializeField] private List<SpawnController> spawns;

    private void Start()
    {
        currentCheckpoint = GetComponent<CheckpointController>();
        playerStats=PlayerManager.instance.Player.GetComponent<CharacterStats>();

        foreach(var spawn in spawns)
        {
            spawn.SpawnMobs();
        }
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
