using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Quest : ScriptableObject
{
    public int id;
    public string questName;
    public bool prerequisitesOk;
    public int goldReward;
    public int xpReward;

    public event Action<Quest> OnQuestCompleted;
    public bool active;
    //public bool completed { get; private set; }
    public bool completed;
    [TextArea]
    public string questDescription;
    //public int completedObjectives = 0;
    public int objectiveGoalProgress = 0;
    public int objectiveGoal = 0;
    public List<Objective> objectives = new List<Objective>();

    public void TryEndQuest()
    {
        for (int i = 0; i < objectives.Count; i++)
        {
            if (objectives[i].Completed != true)
            {
                if (objectives[i].required)
                {
                    // the quest is not complete
                    return;
                }
            }
            //if (objectives[i].Completed == true)
            //{ 
            //    completedObjectives++;
            //}

            completed = true;
            active = false;

            OnQuestCompleted?.Invoke(this);
        }
    }

    void OnEnable()
    {
        for (int i = 0; i < objectives.Count; i++)
        {
            objectives[i].parentQuest = this;
        }
    }
}



