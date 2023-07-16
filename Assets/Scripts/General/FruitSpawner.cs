using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject[] fruits;
    [SerializeField] 
    private float spawnRate;
    
    [SerializeField] 
    private EventHandler eventHandler;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private Transform container;

    private bool _isSpawning;
    
    private void OnEnable()
    {
        eventHandler.OnGameStarted += StartSpawner;
        eventHandler.OnGameFinished += StopSpawner;
    }

    private void OnDisable()
    {
        eventHandler.OnGameStarted -= StartSpawner;
        eventHandler.OnGameFinished -= StopSpawner;
    }

    private void StartSpawner()
    {
        _isSpawning = true;
        StartCoroutine(SpawnerRoutine());
    }

    private void StopSpawner()
    {
        _isSpawning = false;
    }

    private IEnumerator SpawnerRoutine()
    {
        while (_isSpawning)
        {
            SpawnFruit(ChooseFruitToSpawn(fruits.Length));
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private int ChooseFruitToSpawn(int fruitsAmount)
    {
        var fruitToSpawn = Random.Range(0, fruitsAmount);
        return fruitToSpawn;
    }

    private void SpawnFruit(int fruitToSpawn)
    {
        Instantiate(fruits[fruitToSpawn], spawnPoint.position, Quaternion.identity, container); //TODO: Unity pool
    }
}
