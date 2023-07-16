using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class QuestController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questInfoText;
    [SerializeField] private TextMeshProUGUI questProgressionText;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private EventHandler eventHandler;
    
    private int _questCount;
    private int _collectedCount = 0;
    private string _name;

    private void OnEnable()
    {
        eventHandler.OnFruitCollected += IncreaseQuestProgression;
        eventHandler.OnGameFinished += ClearQuest;
    }

    private void OnDisable()
    {
        eventHandler.OnFruitCollected -= IncreaseQuestProgression;
        eventHandler.OnGameFinished -= ClearQuest;
    }

    public void GenerateQuest()
    {
        _questCount = Random.Range(1, 6);
        var fruitId = Random.Range(0, 3);
        switch (fruitId)
        {
            case 0:
                _name = "Apple";
                break;
            case 1:
                _name = "Banana";
                break;
            case 2:
                _name = "Orange";
                break;
        }
        playerController.SetQuestFruitName(_name);
        if (_questCount == 1)
        {
            questInfoText.text = _questCount + " " + _name;
        }
        else{questInfoText.text = _questCount + " " + _name+"s";}
        UpdateQuestProgression();
    }

    public void UpdateQuestProgression()
    {
        questProgressionText.text = _collectedCount+"/"+_questCount;
        if (_collectedCount == _questCount)
        {
            eventHandler.InvokeOnQuestCompleted();
        }
    }

    public void IncreaseQuestProgression(GameObject obj)
    {
        _collectedCount++;
        UpdateQuestProgression();
    }

    private void ClearQuest()
    {
        _collectedCount = 0;
        _questCount = 0;
        _name = " ";
    }
}
