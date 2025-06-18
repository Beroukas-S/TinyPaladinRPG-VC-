using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LeaderTalkSecondObj : MonoBehaviour
{
    [SerializeField] public Objective Objective2;


    [SerializeField] private QuestSystem questSystem;
    [SerializeField] private Quest thirdQuest;

    public void TalkedForSecondObj()
    {
        questSystem.ReceiveNewQuest(thirdQuest);
    }
}
