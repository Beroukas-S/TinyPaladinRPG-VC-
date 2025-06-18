using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class QuestTracking : ScriptableObject
{
    public Quest activeQuest;

    public void setActiveQuest(Quest _activeQuest)
    {
        activeQuest = _activeQuest;
    }
}
