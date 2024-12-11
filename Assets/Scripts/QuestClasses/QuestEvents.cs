using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestEvents : MonoBehaviour
{
    public delegate void QuestActivated(Quest quest);
    public static event QuestActivated OnQuestActivation;

    public delegate void QuestCompleted(int gold, int exp);
    public static event QuestCompleted OnQuestCompletion;

    public void ActivateQuest(Quest activatedQuest)
    {
        OnQuestActivation(activatedQuest);
    }

    public void CompleteQuest(Quest completedQuest)
    {
        OnQuestCompletion(completedQuest.goldReward, completedQuest.xpReward);
    }

}
