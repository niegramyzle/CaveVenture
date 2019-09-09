using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject gameMenu;
    [SerializeField] private GameObject controlsPanel;

    public void ResumeGame()
    {
        gameMenu.SetActive(false);
        Cursor.visible = false;
    }

    public void Controls()
    {
        gameMenu.SetActive(false);
        controlsPanel.SetActive(true);
    }

    public void Back()
    {
        gameMenu.SetActive(true);
        controlsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OnUpdate()
    {
        if (PlayerManager.instance.Player.GetComponent<InteractionInputController>().OnEscape())
        {
            gameMenu.SetActive(!gameMenu.activeSelf);
            controlsPanel.SetActive(false);
            Debug.Log(gameMenu.activeSelf);
            Cursor.visible = gameMenu.activeSelf ? true : false;
        }
    }

    public void OnEndGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void Update()
    {
        OnUpdate();
    }
}
