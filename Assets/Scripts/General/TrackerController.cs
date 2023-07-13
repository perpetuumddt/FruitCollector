using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerController : MonoBehaviour
{
    public void Tracking(float a)
    {
        var transformPosition = transform.position;
        transformPosition.x = a;
        transform.position = transformPosition;
    }
}
