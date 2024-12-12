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

    List<int> completedQuestsIDs = new List<int>();

    private void Awake()
    {
        completedQuestsIDs.Add(0);
    }
    public void ActivateQuest(Quest activatedQuest)
    {
        foreach (int id in completedQuestsIDs)
        {
            if (id == activatedQuest.questPrerequisiteID)
            {
                OnQuestActivation(activatedQuest);
            }
        }
    }

    public void CompleteQuest(Quest completedQuest)
    {
        OnQuestCompletion(completedQuest.goldReward, completedQuest.xpReward);
        completedQuestsIDs.Add(completedQuest.id);
    }



}
