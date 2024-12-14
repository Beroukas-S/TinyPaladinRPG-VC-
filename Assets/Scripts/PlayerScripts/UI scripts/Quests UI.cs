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
    [SerializeField] private QuestSystem questSystem;

    //private void Awake()
    //{
    //    activeQuest = GetComponent<ZeroQuest>();
    //}


    private void Update()
    {
        UpdateCanvas();
    }

    public void UpdateActiveQuest(Quest currentQuest)
    {
        activeQuest = currentQuest;
        if (currentQuest.completed == true)
        { 
            activeQuest = null;
        }
    }

    private void OnEnable()
    {
        QuestSystem.OnQuestActivationStatic += UpdateActiveQuest;
        QuestSystem.OnQuestComplitionStatic += UpdateActiveQuest;
    }

    private void OnDisable()
    {
        QuestSystem.OnQuestActivationStatic -= UpdateActiveQuest;
        QuestSystem.OnQuestComplitionStatic -= UpdateActiveQuest;
    }





    public void UpdateCanvas()
    {
        if (activeQuest != null)
        {
            questTitleText.text = $"{activeQuest.questName}";
            goalText.text = $"{activeQuest.questDescription}";
            progressText.text = $"{activeQuest.objectiveGoalProgress} / {activeQuest.objectiveGoal}";
            rewardsText.text = $"{activeQuest.goldReward} Gold {activeQuest.xpReward} XP";
        }
        else
        {
            questTitleText.text = $"No active quest.";
            goalText.text = $"";
            progressText.text = $"";
            rewardsText.text = $"";
        }
    }


}
