using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;
    public delegate void EndTouch(Vector2 position, float time);
    public event StartTouch OnEndTouch;

    //public static InputManager Instance;

    private PlayerControls _playerControls;
    private Camera _mainCamera;


    private void Awake()
    {
        //Instance = this;
        _playerControls = new PlayerControls();
        _mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls?.Disable();
    }

    private void Start()
    {
        _playerControls.Touch.TouchPrimary.started += ctx => StartTouchPrimary(ctx);
        _playerControls.Touch.TouchPrimary.canceled += ctx => EndTouchPrimary(ctx);
    }


    public Vector2 TouchPosition()
    {
        return Utils.ScreenToWorld(_mainCamera, _playerControls.Touch.TouchPosition.ReadValue<Vector2>());
    }

    private void StartTouchPrimary(InputAction.CallbackContext ctx)
    {
        if(OnStartTouch != null)
        {
            OnStartTouch(Utils.ScreenToWorld(_mainCamera, _playerControls.Touch.TouchPosition.ReadValue<Vector2>()), (float)ctx.startTime);
            //OnStartTouch(_playerControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)ctx.startTime);
        }
    }
    private void EndTouchPrimary(InputAction.CallbackContext ctx)
    {
        if (OnEndTouch != null)
        {
            OnEndTouch(Utils.ScreenToWorld(_mainCamera, _playerControls.Touch.TouchPosition.ReadValue<Vector2>()), (float)ctx.time);
            //OnEndTouch(_playerControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)ctx.time);
        }
    }

}
