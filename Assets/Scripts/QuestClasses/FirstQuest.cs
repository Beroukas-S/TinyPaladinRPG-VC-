using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstQuest : Quest
{
    public QuestEvents questEvents;
    private void Start()
    {
        ChangeQuestState(QuestState.Pending);
        id = 1;
        questName = "Talk to the leader.";
        goldReward = 0;
        xpReward = 10;

    }

    protected override void ChangeQuestState(QuestState newState)
    {
        state = newState;
    }

    private void OnEnable()
    {
        //Klasi me to event pou tou milaw.OnTouMilisa += CheckProgress;
    }

    private void OnDisable()
    {
        //Klasi me to event pou tou milaw.OnTouMilisa -= CheckProgress;
    }

    public override void ActivateQuest()
    {
        ChangeQuestState(QuestState.Active);
    }

    public override void CompleteQuest()
    {
        ChangeQuestState(QuestState.Completed);
        questEvents.CompleteQuest(this);
    }

}
