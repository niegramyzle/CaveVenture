using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    List<EnemyController> enemies;

    // Update is called once per frame
    void Update()
    {
        foreach(var enemy in enemies)
        {
            enemy.UpdateEnemy();
        }
    }
}
