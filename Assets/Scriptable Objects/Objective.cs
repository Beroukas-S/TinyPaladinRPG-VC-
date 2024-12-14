using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Objective : ScriptableObject
{
    [HideInInspector] public Quest parentQuest;
    public bool required = true;
    public bool Completed { get; private set; }
    [TextArea]
    public string description;

    public void CompleteObjective()
    {
        Completed = true;
        parentQuest.TryEndQuest();
    }

    public void ProgressObjective()
    {
        parentQuest.objectiveGoalProgress++;
        if (parentQuest.objectiveGoalProgress == parentQuest.objectiveGoal)
        { 
            CompleteObjective();
        }
    }
}
