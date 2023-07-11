using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    private Transform _spawnPoint;
    private Transform _destroyPoint;
    private void Start()
    {
        _destroyPoint = GameObject.FindWithTag("DestroyPoint").transform;
        //DoMove();
    }

    private void Update()
    {
        transform.position =
            Vector3.MoveTowards(transform.position, _destroyPoint.transform.position, 3 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == CompareTag("DestroyPoint"))
        {
            Destroy(this.gameObject);
        }
    }

    private void DoMove()
    {
        transform.position =
            Vector3.MoveTowards(transform.position, _destroyPoint.transform.position, 5 * Time.deltaTime);
    }

    private void OnCollected()
    {
        
    }
}
