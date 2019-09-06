using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    #region Singleton
    public static EnemyManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public List<EnemyController> enemies;

    public void Clear()
    {
        enemies.Clear();
    }

    public void OnUpdate()
    {
        //Debug.Log("EnemyManageroup");
        //   Debug.Log("fffd");
        foreach (var enemy in enemies)
        {
            if (enemy.gameObject.activeSelf && !enemy.IsDied())
            {
                enemy.UpdateEnemy();
            }
        }
    }
}
