using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class TouchManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    
    private InputAction _touchPressedAction;
    private InputAction _touchPositionAction;
    
    private Camera _mainCam;

    private Ray _ray;
    private RaycastHit _hit;
    
    private void Awake()
    {
        _mainCam = Camera.main;
        _playerInput = GetComponent<PlayerInput>();
        _touchPressedAction = _playerInput.actions.FindAction("TouchPressed");
        _touchPositionAction = _playerInput.actions.FindAction("TouchPosition");
    }

    private void OnEnable()
    {
        _touchPositionAction.performed += TouchPosition;
    }

    private void OnDisable()
    {
        _touchPositionAction.performed -= TouchPosition;
    }
    
    public void TouchPosition(InputAction.CallbackContext context)
    {
        _ray = _mainCam.ScreenPointToRay(context.ReadValue<Vector2>());
        if (Physics.Raycast(_ray, out _hit))
        {
            if (_hit.collider.CompareTag("Fruit"))
            {
                _hit.transform.GetComponent<FruitController>().OnClicked();
            }
        }
    }
}
