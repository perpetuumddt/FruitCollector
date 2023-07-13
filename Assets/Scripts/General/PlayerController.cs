using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject _tracker;
    private EventHandler _eventHandler;
    
    [SerializeField] private Animator _animator;
    private static readonly int IsDancing = Animator.StringToHash("isDancing");
    private static readonly int IsIdle = Animator.StringToHash("isIdle");
    private static readonly int IsPickingUp = Animator.StringToHash("IsPickingUp");

    private string _questFruitName;
    
    private void Awake()
    {
        _tracker = GameObject.FindWithTag("Tracker");
        _eventHandler = GameObject.FindWithTag("EventHandler").GetComponent<EventHandler>();
    }

    private void OnEnable()
    {
        _eventHandler.OnFruitPickedUp += FruitPickedUp;
    }

    private void OnDisable()
    {
        _eventHandler.OnFruitPickedUp -= FruitPickedUp;
    }

    private void Start()
    {
        _animator.SetTrigger(IsPickingUp);
    }

    private void FruitSelected()
    {
    }

    private void FruitPickedUp(GameObject obj)
    {
        if (obj.gameObject.name == _questFruitName+"(Clone)")
        {
            _eventHandler.InvokeOnFruitCollected();
        }
    }

    public void SetQuestFruitName(string name)
    {
        this._questFruitName = name;
    }
}
