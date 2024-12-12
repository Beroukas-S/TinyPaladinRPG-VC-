using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuCanvasUI : MonoBehaviour
{
    public CanvasGroup menuCanvas;
    public CanvasGroup statsCanvas;
    public CanvasGroup questCanvas;
    private bool menuOpen;
    [SerializeField] private Button statsButton;
    [SerializeField] private Button questsButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;
    // Start is called before the first frame update
    void Start()
    {
        menuCanvas.alpha = 0;
        menuOpen = false;
        statsCanvas.alpha = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ToggleStats"))
        {
            if (menuOpen)
            {
                Time.timeScale = 1;
                menuCanvas.alpha = 0;
                menuOpen = false;
            }
            else
            {
                Time.timeScale = 0;
                menuCanvas.alpha = 1;
                menuOpen = true;
            }
        }
    }

    public void PressStats()
    {
        statsCanvas.alpha = 1;
        questCanvas.alpha = 0;
        statsButton.image.color = Color.white;
        questsButton.image.color = Color.grey;
        optionsButton.image.color = Color.grey;
        exitButton.image.color = Color.grey;
    }

    public void PressQuests()
    {
        statsCanvas.alpha = 0;
        questCanvas.alpha = 1;
        statsButton.image.color = Color.grey;
        questsButton.image.color = Color.white;
        optionsButton.image.color = Color.grey;
        exitButton.image.color = Color.grey;
    }

    public void PressExit()
    {
        Application.Quit();
    }
}
