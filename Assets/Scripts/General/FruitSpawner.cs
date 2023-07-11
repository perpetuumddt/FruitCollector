using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject[] _fruits;
    [SerializeField] 
    private float spawnRate;

    private Transform spawnPoint;
    private Transform container;
    private bool _isSpawning = true;

    private void Start()
    {
        spawnPoint = GameObject.FindWithTag("SpawnPoint").transform;
        container = GameObject.FindWithTag("FruitsContainer").transform;

        StartCoroutine(StartSpawner());
    }

    /*
    private void OnEnable()
    {
        throw new NotImplementedException();
    }

    private void OnDisable()
    {
        throw new NotImplementedException();
    }*/

    private IEnumerator StartSpawner()
    {
        while (_isSpawning)
        {
            SpawnFruit(ChooseFruitToSpawn(_fruits.Length));
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private void StopSpawning()
    {
        _isSpawning = false;
    }
    
    private int ChooseFruitToSpawn(int fruitsAmount)
    {
        var fruitToSpawn = Random.Range(0, fruitsAmount);
        return fruitToSpawn;
    }

    private void SpawnFruit(int fruitToSpawn)
    {
        //Instantiate(_fruits[fruitToSpawn], spawnPoint.position, Quaternion.identity);
        Instantiate(_fruits[fruitToSpawn], spawnPoint.position, Quaternion.identity, container);
    }
}
