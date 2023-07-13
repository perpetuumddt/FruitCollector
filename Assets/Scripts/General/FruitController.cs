using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    private Transform _destroyPoint;
    private TrackerController _tracker;
    private EventHandler _eventHandler;

    private bool isTracking = false;
    private bool isCollectable = false;
    private bool isMoving = true;

    private void Awake()
    {
        _destroyPoint = GameObject.FindWithTag("DestroyPoint").transform;
        _tracker = GameObject.FindWithTag("Tracker").GetComponent<TrackerController>();
        _eventHandler = GameObject.FindWithTag("EventHandler").GetComponent<EventHandler>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, _destroyPoint.transform.position, 3 * Time.deltaTime);
        }
        if (isTracking)
        {
            _tracker.Tracking(transform.position.x);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DestroyPoint"))
        {
            Destroy(this.gameObject);
        }

        if (isCollectable && other.gameObject.CompareTag("FruitPicker"))
        {
            OnCollected();
        }
    }

    private void OnCollected()
    {
        isMoving = false;
        isTracking = false;
        isCollectable = false;
        _eventHandler.InvokeOnFruitPickedUp(this.gameObject);
    }

    public void OnClicked()
    {
        isTracking = true;
        isCollectable = true;
        _eventHandler.InvokeOnFruitSelected(true);
    }
    
    
}
