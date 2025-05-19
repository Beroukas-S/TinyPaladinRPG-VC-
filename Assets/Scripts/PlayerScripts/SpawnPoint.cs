using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public SceneTracker lastScene;
    public SceneTracker newScene;
    public Transform playerTransform;

    void Awake()
    {
        switch (newScene.scene)
        {
            case SceneTracker.SceneList.KnightVillage:
                switch (lastScene.scene)
                {
                    case SceneTracker.SceneList.MainMenu:
                        playerTransform.position = new Vector3(-972.35f, -556.2f, 0);
                        playerTransform.localScale = new Vector3(1f, 1f, 0);
                        break;
                    case SceneTracker.SceneList.GoblinVillage:
                        playerTransform.position = new Vector3(-878.05f, -521.61f, 0);
                        playerTransform.localScale = new Vector3(1f, -1f, 0);
                        break;
                    case SceneTracker.SceneList.WarlordIsland:
                        playerTransform.position = new Vector3(-931.79f, -521.42f, 0);
                        playerTransform.localScale = new Vector3(1f, 1f, 0);
                        break;
                }
                break;
            case SceneTracker.SceneList.GoblinVillage:
                playerTransform.position = new Vector3(-945.65f, -528.6f, 0);
                playerTransform.localScale = new Vector3(1f, 1f, 0);
                break;
            case SceneTracker.SceneList.WarlordIsland:
                playerTransform.position = new Vector3(-876.07f, -521.64f, 0);
                playerTransform.localScale = new Vector3(1f, -1f, 0);
                break;
        }
    }
}
