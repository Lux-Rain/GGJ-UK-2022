using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlsReader : ScriptableObject, Controls.INormalActions, Controls.ICameraActions
{
    private Controls _controls;
    public Action<Vector2> OnMoveEvent;
    public Action<Vector2> OnLookEvent;
    public Action<bool> OnRunEvent;
    public Action OnJumpEvent;
    public Action OnCaptureEvent;
    public Action<bool> OnCameraEvent;
    public Action<float> OnZoomEvent;

    public void CreateControl()
    {
        _controls = new Controls();
    }
    
    public void EnableControl()
    {
        _controls.Normal.SetCallbacks(this);
        _controls.Normal.Enable();
    }

    public void DisableControl()
    {
        _controls.Normal.SetCallbacks(null);
        _controls.Camera.SetCallbacks(null);
        _controls.Normal.Disable();
    }

    public void EnableCamera()
    {
        _controls.Camera.SetCallbacks(this);
        _controls.Camera.Enable();
    }
    
    public void DisableCamera()
    {
        _controls.Camera.SetCallbacks(null);
        _controls.Camera.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        OnMoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        OnLookEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnRunEvent?.Invoke(true);
        } else if (context.canceled)
        {
            OnRunEvent?.Invoke(false);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnJumpEvent?.Invoke();
        }
    }

    public void OnEnableCamera(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnCameraEvent?.Invoke(true);
        } else if (context.canceled)
        {
            OnCameraEvent?.Invoke(false);
        }
    }

    public void OnCapture(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnCaptureEvent?.Invoke();
        }
    }

    public void OnZoom(InputAction.CallbackContext context)
    {
        OnZoomEvent?.Invoke(context.ReadValue<float>());
    }
}
