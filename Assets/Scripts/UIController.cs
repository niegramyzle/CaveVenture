using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private CharacterStats stats;
    [SerializeField] private Text lifeBox;

    private void Start()
    {
        stats = GetComponent<CharacterStats>();
    }

    private void UpdateLifeBox()
    {
        lifeBox.text = "Lifes points: " + stats.Health;
    }

    void Update()
    {
        UpdateLifeBox();
    }
}
