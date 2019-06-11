using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private bool isPlayerAlive()
    {
        return true;
    }

    private void gameOver()
    {
        //SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerAlive())
        {
            
        }
        else
        {
            gameOver();
        }
    }
}
