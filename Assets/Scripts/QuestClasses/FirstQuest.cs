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
        questName = "Introductions";
        questDescription = "Talk to the village leader.";
        questPrerequisiteID = 0;
        goldReward = 0;
        xpReward = 10;
        questProgress = 0;
        questGoal = 1;
    }

    protected override void ChangeQuestState(QuestState newState)
    {
        state = newState;
    }

    private void OnEnable()
    {
        BridgeGuard.OnTalkingToBridgeGuard += ActivateQuest;
        //Klasi me to event pou tou milaw.OnTouMilisa += CheckProgress;
    }

    private void OnDisable()
    {
        BridgeGuard.OnTalkingToBridgeGuard -= ActivateQuest;
        //Klasi me to event pou tou milaw.OnTouMilisa -= CheckProgress;
    }

    public override void CheckProgress()
    {
        questProgress++;
        if (questProgress == questGoal)
        {
            CompleteQuest();
        }
    }

    public override void ActivateQuest()
    {
        ChangeQuestState(QuestState.Active);
        questEvents.ActivateQuest(this);
    }

    public override void CompleteQuest()
    {
        ChangeQuestState(QuestState.Completed);
        questEvents.CompleteQuest(this);
    }

}
