using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    [SerializeField] private QuestController questController;
    private EventHandler _eventHandler;

    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameplayScreen _gameplayScreen;
    [SerializeField] private EndgameScreen _endgameScreen;

    [SerializeField] private Transform _conveyorTransform;
    
    private void Awake()
    {
        _eventHandler = GameObject.FindWithTag("EventHandler").GetComponent<EventHandler>();
    }

    private void Start()
    {
        SetupGame();
    }

    private void OnEnable()
    {
        _eventHandler.OnQuestCompleted += FinishGame;
        _eventHandler.OnGameStarted += StartGame;
    }

    private void OnDisable()
    {
        _eventHandler.OnQuestCompleted -= FinishGame;
        _eventHandler.OnGameStarted -= StartGame;
    }

    private void SetupGame()
    {
        _startScreen.ActivateScreen();
    }

    private void StartGame()
    {
        StartCoroutine(SetupConveyor());
        questController.GenerateQuest();
        _startScreen.DeactivateScreen();
        _gameplayScreen.ActivateScreen();
    }

    private IEnumerator SetupConveyor()
    {
        var isMoving = true;
        Vector3 conveyorPos = new Vector3(-0.76f,1.075f,4.34f);
        while (isMoving)
        {
            _conveyorTransform.transform.position = Vector3.MoveTowards(_conveyorTransform.position,conveyorPos,0.1f * Time.deltaTime);
            if (_conveyorTransform.transform.position == conveyorPos)
            {
                isMoving = false;
            }
        }

        yield return null;
    }
    
    private void FinishGame()
    {
        _eventHandler.InvokeOnGameFinished();
        _gameplayScreen.DeactivateScreen();
        _endgameScreen.ActivateScreen();
    }
}
