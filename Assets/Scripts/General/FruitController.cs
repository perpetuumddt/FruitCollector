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
    }

    private void Update()
    {
        transform.position =
            Vector3.MoveTowards(transform.position, _destroyPoint.transform.position, 3 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DestroyPoint"))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollected()
    {
        
    }
}
