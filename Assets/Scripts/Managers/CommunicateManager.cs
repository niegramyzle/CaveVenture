using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommunicateManager : MonoBehaviour
{
    public static CommunicateManager instance;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Text TextBox;

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
    
    public void ResetText()
    {
        TextBox.text = "";
    }

    public void ShowMessageOnUI(string text)
    {
        TextBox.text = text;
    }
}
