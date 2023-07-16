using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public event Action OnFruitSelected;
    public event Action<GameObject> OnFruitPickedUp;
    public event Action<GameObject> OnFruitCollected;

    public event Action OnQuestCompleted; 

    public event Action OnGameStarted;
    public event Action OnGameFinished;


    public virtual void InvokeOnFruitSelected()
    {
        OnFruitSelected?.Invoke();
    }

    public virtual void InvokeOnFruitPickedUp(GameObject obj)
    {
        OnFruitPickedUp?.Invoke(obj);
    }

    public virtual void InvokeOnFruitCollected(GameObject obj)
    {
        OnFruitCollected?.Invoke(obj);
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
