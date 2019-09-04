using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject gameMenu;

    public void ResumeGame()
    {
        gameMenu.SetActive(false);
    }

    public void Controls()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OnUpdate()
    {
        if (PlayerManager.instance.Player.GetComponent<InteractionInputController>().OnEscape())
        {
            if(gameMenu.activeSelf)
                gameMenu.SetActive(false);
            else
                gameMenu.SetActive(true);
        }
    }

    private void Update()
    {
        OnUpdate();
    }
}
