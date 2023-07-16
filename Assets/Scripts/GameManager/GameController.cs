using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    [SerializeField] private QuestController questController;
    [SerializeField] private EventHandler eventHandler;
    [SerializeField] private StartScreen startScreen;
    [SerializeField] private GameplayScreen gameplayScreen;
    [SerializeField] private EndgameScreen endgameScreen;
    [SerializeField] private Transform conveyorTransform;

    private void Start()
    {
        SetupGame();
    }

    private void OnEnable()
    {
        eventHandler.OnQuestCompleted += FinishGame;
        eventHandler.OnGameStarted += StartGame;
        eventHandler.OnFruitCollected += gameplayScreen.FloatingText;
    }

    private void OnDisable()
    {
        eventHandler.OnQuestCompleted -= FinishGame;
        eventHandler.OnGameStarted -= StartGame;
        eventHandler.OnFruitCollected -= gameplayScreen.FloatingText;
    }

    private void SetupGame()
    {
        startScreen.ActivateScreen();
    }

    private void StartGame()
    {
        SetupConveyor();
        questController.GenerateQuest();
        startScreen.DeactivateScreen();
        endgameScreen.DeactivateScreen();
        gameplayScreen.ActivateScreen();
        
    }
    
    private void FinishGame()
    {
        RemoveConveyor();
        eventHandler.InvokeOnGameFinished();
        gameplayScreen.DeactivateScreen();
        endgameScreen.ActivateScreen();
    }

    private void SetupConveyor()
    {
        Vector3 conveyorPos = new Vector3(-0.76f,1.075f,4.34f);
        conveyorTransform.transform.position = conveyorPos;
    }

    private void RemoveConveyor()
    {
        Vector3 conveyorPos = new Vector3(-0.76f, -1f, 4.34f);
        conveyorTransform.transform.position = conveyorPos;
    }
}
