using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class GameManager : MonoBehaviour
{
    private CheckpointController currentCheckpoint;
    private CharacterStats playerStats;
    [SerializeField] private GameObject deadInfo;
    [SerializeField] private Button spawnButton;

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

    public void respawnPlayer()
    {
        Time.timeScale = 1;
        deadInfo.SetActive(false);
        PlayerManager.instance.Player.GetComponent<CharacterController>().enabled = false;
        PlayerManager.instance.Player.transform.position=currentCheckpoint.CurrentCheckpoint;
        PlayerManager.instance.Player.GetComponent<CharacterController>().enabled = true;
        playerStats.resetStats();
    }

    void Update()
    {
        if (isPlayerDead())
        {
            deadInfo.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
