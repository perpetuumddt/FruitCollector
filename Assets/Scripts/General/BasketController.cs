using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    [SerializeField] private GameObject[] fruitHolder;
    [SerializeField] private EventHandler eventHandler;

    private GameObject[] _fruits;
    private int _fruitAmount;
    
    private void OnEnable()
    {
        eventHandler.OnFruitCollected += AddFruitToHolder;
        eventHandler.OnGameStarted += ResetFruitHolder;
    }

    private void OnDisable()
    {
        eventHandler.OnFruitCollected -= AddFruitToHolder;
        eventHandler.OnGameStarted -= ResetFruitHolder;
    }

    private void AddFruitToHolder(GameObject obj)
    {
        obj.transform.position = fruitHolder[_fruitAmount].transform.position;
        obj.gameObject.transform.parent = fruitHolder[_fruitAmount].transform;
        _fruitAmount++;
    }

    private void ResetFruitHolder()
    {
        for (int i = 0; i < _fruitAmount; i++)
        {
            foreach (Transform child in fruitHolder[i].transform)
            {
                Destroy(child.gameObject);
            }
        }
        _fruitAmount = 0;
    }
}
