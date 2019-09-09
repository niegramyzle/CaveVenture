using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class GameManager : MonoBehaviour
{
    private CheckpointController currentCheckpoint;
    private CharacterStats playerStats;
    [SerializeField] private GameObject deadInfo;
    [SerializeField] private GameObject endInfo;

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
        Cursor.visible = false;
        deadInfo.SetActive(false);
        PlayerManager.instance.Player.GetComponent<CharacterController>().enabled = false;
        PlayerManager.instance.Player.transform.position=currentCheckpoint.CurrentCheckpoint;
        PlayerManager.instance.Player.GetComponent<CharacterController>().enabled = true;
        playerStats.resetStats();
    }

    void Update()
    {
        //Debug.Log("GameManagerUP");
        if (isPlayerDead())
        {
            deadInfo.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        EnemyManager.instance.OnUpdate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject==PlayerManager.instance.Player)
        {
            Cursor.visible = true;
            //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            endInfo.SetActive(true);
            Time.timeScale = 0;
            Destroy(gameObject);
            //PlayerManager.instance = null;
            //EnemyManager.instance = null;
        }
    }
}
