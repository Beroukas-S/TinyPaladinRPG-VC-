using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    public Quest currentQuest;
    public List<Quest> openQuests;
    public static event Action<Quest> OnQuestComplitionStatic;
    public static event Action<Quest> OnQuestActivationStatic;

    public void ReceiveNewQuest(Quest quest)
    {
        openQuests.Add(quest);
        quest.active = true;

        OnQuestActivationStatic(quest);

        currentQuest = quest;

        quest.OnQuestCompleted += RemoveCompletedQuest;
    }

    void RemoveCompletedQuest(Quest quest)
    {
        OnQuestComplitionStatic(quest);
        if (currentQuest == quest)
        {
            currentQuest = null;
        }

        quest.OnQuestCompleted -= RemoveCompletedQuest;
        openQuests.Remove(quest);

        if (openQuests.Count > 0)
        {
            // sets the next quest in the list as the current quest
            currentQuest = openQuests[0];
        }
    }
}
