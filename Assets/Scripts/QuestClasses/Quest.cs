using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quest : MonoBehaviour
{
    public int id;
    public string questName;
    public QuestState state;
    public Quest questPrerequisite;
    public int goldReward;
    public int xpReward;

    public enum QuestState
    {
        Pending,
        Active,
        Completed
    }

    protected abstract void ChangeQuestState(QuestState newState);

    //public abstract void CheckProgress();

    public abstract void ActivateQuest();
    public abstract void CompleteQuest();
    
}
