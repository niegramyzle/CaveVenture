using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private EnemyManager enemyManager;
    [SerializeField] Transform templateMob;
    [SerializeField] float maxRange=0;
    [SerializeField] int enemiesCount=0;
    void Start()
    {
        enemyManager=EnemyManager.instance;
    }

    public void SpawnMobs()
    {
        Vector3 offset = new Vector3();
        Quaternion quat = new Quaternion();
        int num=enemiesCount;
        var enemies = enemyManager.enemies;
        foreach(var mob in enemies)
        {
            offset.x = Random.Range(0, maxRange);
            offset.z = Random.Range(0, maxRange);
            quat = Quaternion.Euler(0, Random.Range(0, 360.0f), 0);
            if (!mob.gameObject.activeSelf)
            {
                mob.gameObject.SetActive(true);
                mob.GetComponent<CharacterStats>().resetStats();
                num--;
                if(num<=0)
                {
                    break;
                }
            }
        }
        if(num>0)
        {
            for(;num>0 ;num--)
            {
                offset.x = Random.Range(0, maxRange);
                offset.z = Random.Range(0, maxRange);
                quat = Quaternion.Euler(0, Random.Range(0, 360.0f), 0);
                var newMob=Instantiate(templateMob, transform.position+ offset, quat);
                enemies.Add(newMob.GetComponent<EnemyController>());
            }
        }
    }

}
