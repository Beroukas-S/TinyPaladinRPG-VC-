using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LeaderTalkFirstObj : MonoBehaviour
{
    [SerializeField] public Objective Objective1;


    [SerializeField] private QuestSystem questSystem;
    [SerializeField] private Quest secondQuest;

    public void TalkedForFirstObj()
    {
        Objective1.CompleteObjective();
        questSystem.ReceiveNewQuest(secondQuest);
    }
}
