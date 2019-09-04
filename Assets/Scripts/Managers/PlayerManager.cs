using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    [SerializeField]
    private GameObject player;
    public  GameObject Player
    {
        get { return player; }
        set { player = value; }
    }

    private void Awake()
    {
        //Debug.Log("PlayManagerAw");
        //if (instance == null)
        //{
        //    instance = this;
        //}
        //else
        //{
        //    Destroy(gameObject);
        //    return;
        //}
        instance = this;
    }


    
}
