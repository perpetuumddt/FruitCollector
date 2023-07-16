using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    private float _destroyTime = 0.9f;
    private Vector3 _offset = new Vector3(0, 1, 0);
    private Animator _animator;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.Play("FloatingText");
        Destroy(gameObject,_destroyTime);
    }

    private void Update()
    {
        transform.position += new Vector3(0, 1, 0);
    }
}
