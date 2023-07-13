using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    [SerializeField] private QuestController questController;
    private EventHandler _eventHandler;

    private void Awake()
    {
        _eventHandler = GameObject.FindWithTag("EventHandler").GetComponent<EventHandler>();
    }

    private void Start()
    {
        StartGame();
    }

    private void OnEnable()
    {
        _eventHandler.OnQuestCompleted += FinishGame;
    }

    private void OnDisable()
    {
        _eventHandler.OnQuestCompleted -= FinishGame;
    }

    private void StartGame()
    {
        questController.GenerateQuest();
    }

    private void FinishGame()
    {
        Debug.Log("Completed");
    }
}
