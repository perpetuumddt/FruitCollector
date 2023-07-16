using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class TrackerController : MonoBehaviour
{
    [SerializeField]
    private EventHandler eventHandler;

    [SerializeField]
    private RigBuilder rigBuilder;
    
    [Header("Tracker Transforms")] 
    [Header("Idle")]
    [SerializeField]
    private Transform idleTracker;
    [SerializeField] 
    private Transform idleBodyTracker;
    [SerializeField] 
    private Transform idleArmTracker;
    
    [Header("Fruit Picking")]
    [SerializeField] 
    private Transform fpTracker;
    [SerializeField] 
    private Transform fpBodyTracker;
    [SerializeField] 
    private Transform fpArmTracker;

    [Header("Trackers")] 
    
    [Header("Body")] 
    [SerializeField]
    private MultiAimConstraint spineTracker;
    [SerializeField] 
    private ChainIKConstraint armTracker;

    private void OnEnable()
    {
        eventHandler.OnFruitSelected += TrackOnFruitSelected;
        eventHandler.OnFruitCollected += TrackOnFruitCollected;
    }

    private void OnDisable()
    {
        eventHandler.OnFruitSelected -= TrackOnFruitSelected;
        eventHandler.OnFruitCollected -= TrackOnFruitCollected;
    }

    public void Tracking(Vector3 transformPosition)
    {
        Vector3 newPos;
        newPos = transformPosition;
        fpTracker.position = newPos;
    }

    private void TrackOnFruitSelected()
    {
        var spineData = spineTracker.data.sourceObjects;

        spineData.SetTransform(0,fpBodyTracker.transform);
        var spineOffset = new Vector3(90, 25, 0);
        var armData = fpArmTracker;
        
        spineTracker.data.sourceObjects = spineData;
        spineTracker.data.offset = spineOffset;
        armTracker.data.target = armData;
        
        rigBuilder.Build();
    }

    public void TrackOnFruitCollected(GameObject obj)
    {
        var spineData = spineTracker.data.sourceObjects;

        spineData.SetTransform(0,idleBodyTracker.transform);
        var spineOffset = new Vector3(90, 0, 0);
        var armData = idleArmTracker;
        
        spineTracker.data.sourceObjects = spineData;
        spineTracker.data.offset = spineOffset;
        armTracker.data.target = armData;
        
        rigBuilder.Build();
    }
}
