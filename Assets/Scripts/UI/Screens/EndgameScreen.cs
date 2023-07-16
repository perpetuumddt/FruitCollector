using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class EndgameScreen : ScreenUIController
{
    [SerializeField] private Button startButton;

    private void OnEnable()
    {
        startButton.onClick.AddListener(StartNewGame);
    }

    private void StartNewGame()
    {
        eventHandler.InvokeOnGameStarted();
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
