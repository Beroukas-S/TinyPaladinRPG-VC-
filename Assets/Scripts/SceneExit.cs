using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit : MonoBehaviour
{
    public CanvasGroup playerCanvas;
    public bool inRange = false;
    public Transform SceneExitSpot;
    public Transform player;

    public Collider2D spotCollider;
    public SceneList sceneList;
    public SceneTracker lastScene;
    public SceneTracker newScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetButtonDown("E"))
        {
            switch (sceneList)
            {
                case SceneList.KnightVillage:
                    lastScene.scene = newScene.scene;
                    newScene.scene = SceneTracker.SceneList.KnightVillage;
                    SceneManager.LoadScene("KnightVillage");
                    break;
                case SceneList.GoblinVillage:
                    lastScene.scene = newScene.scene;
                    newScene.scene = SceneTracker.SceneList.GoblinVillage;
                    SceneManager.LoadScene("GoblinVillage");
                    break;
                case SceneList.WarlordIsland:
                    lastScene.scene = newScene.scene;
                    newScene.scene = SceneTracker.SceneList.WarlordIsland;
                    SceneManager.LoadScene("WarlordIsland");
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerCanvas.alpha = 1;
            inRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerCanvas.alpha = 0;
            inRange = false;
        }
    }

    public enum SceneList
    { 
        KnightVillage,
        GoblinVillage,
        WarlordIsland
    }
}
