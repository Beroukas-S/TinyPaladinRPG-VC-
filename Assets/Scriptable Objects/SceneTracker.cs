using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SceneTracker : ScriptableObject

{
    public SceneList scene;
    public enum SceneList
    {
        KnightVillage,
        GoblinVillage,
        WarlordIsland,
        MainMenu
    }
}
