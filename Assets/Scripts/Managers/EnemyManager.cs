using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    #region Singleton
    public static EnemyManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    #endregion

    public List<EnemyController> enemies;
    
    public void OnUpdate()
    {
        foreach (var enemy in enemies)
        {
            if (enemy.gameObject.activeSelf && !enemy.IsDied())
            {
                enemy.UpdateEnemy();
            }
        }
    }
}
