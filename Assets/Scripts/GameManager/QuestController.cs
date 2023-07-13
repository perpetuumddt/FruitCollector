using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class QuestController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questInfoText;
    [SerializeField] private TextMeshProUGUI questProgressionText;

    private PlayerController _playerController;
    private EventHandler _eventHandler;
    
    private int _questCount;
    private int _collectedCount = 0;
    private string _name;

    private void Awake()
    {
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        _eventHandler = GameObject.FindWithTag("EventHandler").GetComponent<EventHandler>();
    }

    private void OnEnable()
    {
        _eventHandler.OnFruitCollected += IncreaseQuestProgression;
    }

    private void OnDisable()
    {
        _eventHandler.OnFruitCollected -= IncreaseQuestProgression;
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
        _playerController.SetQuestFruitName(_name);
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
            _eventHandler.InvokeOnQuestCompleted();
        }
    }

    public void IncreaseQuestProgression()
    {
        _collectedCount++;
        UpdateQuestProgression();
    }
}
