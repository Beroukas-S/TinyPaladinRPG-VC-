using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button newGameButton;
    public Button exitButton;
    public SceneTracker lastScene;
    public SceneTracker newScene;

    void Start()
    {
        newGameButton = GetComponent<Button>();
        exitButton = GetComponent<Button>();
    }

    public void NewGame()
    {
        lastScene.scene = SceneTracker.SceneList.MainMenu;
        newScene.scene = SceneTracker.SceneList.KnightVillage;
        SceneManager.LoadScene("KnightVillage");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
