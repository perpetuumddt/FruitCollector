using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndgameScreen : ScreenUIController
{
    [SerializeField] private Button _startButton;

    private EventHandler _eventHandler;

    private void Awake()
    {
        _eventHandler = GameObject.FindWithTag("EventHandler").GetComponent<EventHandler>();
    }

    private void OnEnable()
    {
        _startButton.onClick.AddListener(StartNewGame);
    }

    private void StartNewGame()
    {
        _eventHandler.InvokeOnGameStarted();
    }
    
    public override void ActivateScreen()
    {
        base.ActivateScreen();
    }

    public override void DeactivateScreen()
    {
        base.DeactivateScreen();
    }
}
