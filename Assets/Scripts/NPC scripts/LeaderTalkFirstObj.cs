using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LeaderTalk : MonoBehaviour
{
    [SerializeField] public Objective Objective;


    [SerializeField] private QuestSystem questSystem;
    [SerializeField] private Quest secondQuest;

    public void TalkedForFirstObj()
    {
        Objective.CompleteObjective();
        questSystem.ReceiveNewQuest(secondQuest);
    }
}
