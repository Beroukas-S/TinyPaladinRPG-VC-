using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeGuardQuest : MonoBehaviour
{
    [SerializeField] private QuestSystem questSystem;
    [SerializeField] private Quest firstQuest;

    public void GiveQuest()
    {
        questSystem.ReceiveNewQuest(firstQuest);
    }
}
