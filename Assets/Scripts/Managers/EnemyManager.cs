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


    [SerializeField]
    List<EnemyController> enemies;

    // Update is called once per frame
    void Update()
    {
        foreach (var enemy in enemies)
        {
            if (enemy.gameObject.activeSelf)
            {
                if (enemy.IsDied())
                {
                    enemy.gameObject.SetActive(false);
                }
                else
                {
                    enemy.UpdateEnemy();
                }
            }

        }
    }
}
