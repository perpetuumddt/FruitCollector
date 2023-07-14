using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public event Action<bool> OnFruitSelected;
    public event Action<GameObject> OnFruitPickedUp;
    public event Action OnFruitCollected;

    public event Action OnQuestCompleted; 

    public event Action OnGameStarted;
    public event Action OnGameFinished;


    public virtual void InvokeOnFruitSelected(bool value)
    {
        OnFruitSelected?.Invoke(value);
    }

    public virtual void InvokeOnFruitPickedUp(GameObject obj)
    {
        OnFruitPickedUp?.Invoke(obj);
    }

    public virtual void InvokeOnFruitCollected()
    {
        OnFruitCollected?.Invoke();
    }

    public virtual void InvokeOnQuestCompleted()
    {
        OnQuestCompleted?.Invoke();
    }

    public virtual void InvokeOnGameStarted()
    {
        OnGameStarted?.Invoke();
    }

    public virtual void InvokeOnGameFinished()
    {
        OnGameFinished?.Invoke();
    }
}
