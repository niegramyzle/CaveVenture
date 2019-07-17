using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private CharacterStats playerStats;

    private void Start()
    {
        playerStats=PlayerManager.instance.Player.GetComponent<CharacterStats>();
    }
    
    private bool isPlayerDead()
    {
        return playerStats.IsDied;
    }

    private void respawnPlayer()
    {

    }

    void Update()
    {
        if (isPlayerDead())
        {
 
        }
    }
}
