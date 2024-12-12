using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestsUI : MonoBehaviour
{
    [SerializeField] public Quest activeQuest;
    [SerializeField] private TextMeshProUGUI questTitleText;
    [SerializeField] private TextMeshProUGUI goalText;
    [SerializeField] private TextMeshProUGUI progressText;
    [SerializeField] private TextMeshProUGUI rewardsText;

    private void Awake()
    {
        activeQuest = GetComponent<ZeroQuest>();
    }

    void Start()
    {
        UpdateCanvas();
    }



    private void OnEnable()
    {
        QuestEvents.OnQuestActivation += GetActiveQuest;
    }

    private void OnDisable()
    {
        QuestEvents.OnQuestActivation -= GetActiveQuest;
    }

    public void GetActiveQuest(Quest activatedQuest)
    { 
        activeQuest = activatedQuest;
    }

    public void UpdateCanvas()
    {
        if (activeQuest is ZeroQuest)
        {
            questTitleText.text = $"{activeQuest.questName}";
            goalText.text = $"";
            progressText.text = $"";
            rewardsText.text = $"";
        }
        else
        {
            questTitleText.text = $"{activeQuest.questName}";
            goalText.text = $"{activeQuest.questDescription}";
            progressText.text = $"{activeQuest.questProgress} / {activeQuest.questGoal}";
            rewardsText.text = $"{activeQuest.goldReward} Gold {activeQuest.xpReward} XP";
        }
    }

    
}
