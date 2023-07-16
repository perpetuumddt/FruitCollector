using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class FruitController : MonoBehaviour
{
    private Transform _destroyPoint;
    private TrackerController _tracker;
    private EventHandler _eventHandler;

    private bool _isTracking;
    private bool _isCollectable;
    private bool _isMoving;
    
    [SerializeField] private GameObject selectedEffect;

    private void OnEnable()
    {
        _isMoving = true;
    }

    private void Awake()
    {
        _destroyPoint = GameObject.FindWithTag("DestroyPoint").transform;
        _tracker = GameObject.FindWithTag("Tracker").GetComponent<TrackerController>();
        _eventHandler = GameObject.FindWithTag("EventHandler").GetComponent<EventHandler>();
    }

    private void Update()
    {
        if (_isMoving)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, _destroyPoint.transform.position, 3 * Time.deltaTime);
        }
        if (_isTracking)
        {
            _tracker.Tracking(transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DestroyPoint"))
        {
            Destroy(gameObject);
        }

        if (_isCollectable && other.gameObject.CompareTag("FruitPicker"))
        {
            OnCollected();
        }
    }

    private void OnCollected()
    {
        _isMoving = false;
        _isTracking = false;
        _isCollectable = false;
        _eventHandler.InvokeOnFruitPickedUp(gameObject);
    }

    public void OnClicked()
    {
        _isTracking = true;
        _isCollectable = true;
        EffectOnSelected();
        _eventHandler.InvokeOnFruitSelected();
    }

    private void EffectOnSelected()
    {
        Instantiate(selectedEffect, transform.position, quaternion.identity);
    }
}
