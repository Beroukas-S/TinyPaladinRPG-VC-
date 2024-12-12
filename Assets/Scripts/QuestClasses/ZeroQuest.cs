using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroQuest : Quest
{
    public override void ActivateQuest()
    {}

    public override void CheckProgress()
    {}

    public override void CompleteQuest()
    {}
        

    protected override void ChangeQuestState(QuestState newState)
    {}

    // Start is called before the first frame update
    void Start()
    {
        ChangeQuestState(QuestState.Completed);
        id = 0;
        questName = "No Active Quest";
        questDescription = "";
        goldReward = 0;
        xpReward = 0;
    }
}
