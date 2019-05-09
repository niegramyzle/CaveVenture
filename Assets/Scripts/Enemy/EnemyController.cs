using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    bool b;
    public void UpdateMe()
    {
        if (!b)
        { Debug.Log("Hey");
            b = true;
        }
    }
}
