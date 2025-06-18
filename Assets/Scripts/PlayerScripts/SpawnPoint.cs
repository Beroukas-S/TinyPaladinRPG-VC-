using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public SceneTracker lastScene;
    public SceneTracker newScene;
    public Transform playerTransform;
    public Transform canvasTransform;
    public Transform projectileTransform;
    public GameObject entryPoint;

    void Awake()
    {
        switch (newScene.scene)
        {
            case SceneTracker.SceneList.KnightVillage:
                switch (lastScene.scene)
                {
                    case SceneTracker.SceneList.MainMenu:
                        entryPoint = GameObject.FindGameObjectWithTag("SceneEntryMenu");
                        playerTransform.position = entryPoint.transform.position;
                        this.faceDirection(1f);
                        //playerTransform.localScale = new Vector3(1f, 1f, 0);
                        //canvasTransform.localScale = new Vector3(1f, 1f, 0);
                        //projectileTransform.localScale = new Vector3(1f, 1f, 0);
                        break;
                    case SceneTracker.SceneList.GoblinVillage:
                        entryPoint = GameObject.FindGameObjectWithTag("SceneEntryGoblins");
                        playerTransform.position = entryPoint.transform.position;
                        this.faceDirection(-1f);
                        break;
                    case SceneTracker.SceneList.WarlordIsland:
                        entryPoint = GameObject.FindGameObjectWithTag("SceneEntryWarlord");
                        playerTransform.position = entryPoint.transform.position;
                        this.faceDirection(1f);
                        break;
                }
                break;
            case SceneTracker.SceneList.GoblinVillage:
                entryPoint = GameObject.FindGameObjectWithTag("SceneEntryKnights");
                playerTransform.position = entryPoint.transform.position;
                this.faceDirection(1f);
                break;
            case SceneTracker.SceneList.WarlordIsland:
                entryPoint = GameObject.FindGameObjectWithTag("SceneEntryKnights");
                playerTransform.position = entryPoint.transform.position;
                this.faceDirection(-1f);
                break;
        }
    }

    private void faceDirection(float _x)
    {
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * _x, transform.localScale.y, transform.localScale.z);
        canvasTransform.localScale = new Vector3(0.01f * _x, canvasTransform.localScale.y, canvasTransform.localScale.z);
        projectileTransform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * _x, projectileTransform.localScale.y, projectileTransform.localScale.z);
    }

}
