using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineSwitcher : MonoBehaviour
{
    private Animator _animator;
    private EventHandler _eventHandler;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _eventHandler = GameObject.FindWithTag("EventHandler").GetComponent<EventHandler>();
    }

    private void OnEnable()
    {
        _eventHandler.OnGameFinished += SwitchCameraEndgame;
        _eventHandler.OnGameStarted += SwitchCameraGameplay;
    }

    private void OnDisable()
    {
        _eventHandler.OnGameFinished -= SwitchCameraEndgame;
        _eventHandler.OnGameStarted -= SwitchCameraGameplay;
    }
    
    private void SwitchCameraStart()
    {
        _animator.Play("Start");
    }
    private void SwitchCameraGameplay()
    {
        _animator.Play("Gameplay");
    }
    private void SwitchCameraEndgame()
    {
        _animator.Play("Endgame");
    }
}
