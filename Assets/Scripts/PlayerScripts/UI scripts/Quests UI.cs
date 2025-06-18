using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestsUI : MonoBehaviour
{
    [SerializeField] public QuestTracking questTracking;
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
        questTracking.setActiveQuest(currentQuest);
        if (currentQuest.completed == true)
        {
            questTracking.setActiveQuest(null);
            //activeQuest = null;
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
        if (questTracking.activeQuest != null)
        {
            questTitleText.text = $"{questTracking.activeQuest.questName}";
            goalText.text = $"{questTracking.activeQuest.questDescription}";
            progressText.text = $"{questTracking.activeQuest.objectiveGoalProgress} / {questTracking.activeQuest.objectiveGoal}";
            rewardsText.text = $"{questTracking.activeQuest.goldReward} Gold {questTracking.activeQuest.xpReward} XP";
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
