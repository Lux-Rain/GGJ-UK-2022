using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private CharacterController _characterController;
    private PlayerControlsReader _input;
    private Vector2 _cameraVelocity;
    private Vector2 _velocity;
    private float _xRotation;
    private float _velocityY;
    private float _speed;
    private bool _isGrounded;
    
    [Header("Character")] 
    [SerializeField]
    private float normalSpeed = 4;
    private float runningSpeed = 7;
    [SerializeField]
    private float jumpForce = 10;
    [Header("Camera")]
    [SerializeField] private Transform camera;
    [SerializeField] private float sensitivity;
    [SerializeField] private Polaroid _polaroid;
    [Header("Ground")] [SerializeField] private Transform checkGround;
    [SerializeField] private float checkGroundRadius;
    [SerializeField] private LayerMask checkGroundedLayer;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _characterController = GetComponent<CharacterController>();
        _input = ScriptableObject.CreateInstance<PlayerControlsReader>();
        _input.CreateControl();
        ListenInput();
        _input.EnableControl();
    }

    private void ListenInput()
    {
        _input.OnMoveEvent += OnMove;
        _input.OnJumpEvent += OnJump;
        _input.OnCameraEvent += OnCamera;
        _input.OnRunEvent += OnRun;
        _input.OnLookEvent += OnLook;
        _input.OnCaptureEvent += Capture;
        _input.OnBookEvent += OnBook;
        _input.OnHideChatBoxEvent += OnHideChatBoxEvent;
    }

    private void OnHideChatBoxEvent()
    {
        UIManager.Instance.RemoveText();
    }

    private void OnBook()
    {
        UIManager.Instance.SetBook();
    }

    private void Capture()
    {
        _polaroid.Capture();
    }

    private void OnMove(Vector2 obj)
    {
        _speed = 4;
        _velocity = obj;
    }
    
    private void OnLook(Vector2 obj)
    {
        _cameraVelocity = obj;
    }

    private void OnRun(bool obj)
    {
        _speed = obj ? runningSpeed : normalSpeed;
    }

    private void OnCamera(bool obj)
    {
        if (obj)
        {
            _input.EnableCamera();
            _polaroid.EnableCam();
        }
        else
        {
            _input.DisableCamera();
            _polaroid.DisableCam();
        }
    }

    private void OnJump()
    {
        _velocityY = jumpForce;
    }

    public void AddJumpForce(float force)
    {
        _velocityY = force;
    }

    private void Update()
    {
        CameraUpdate();
        CheckGround();
    }

    private void CheckGround()
    {
        _isGrounded = Physics.CheckSphere(checkGround.position, checkGroundRadius, checkGroundedLayer);

        if (_isGrounded)
        {
            if (_velocityY <= 0)
            {
                _velocityY = -5;
            }
        }
        else
        {
            _velocityY += Physics.gravity.y * Time.deltaTime;
        }
    }

    private void CameraUpdate()
    {
        transform.Rotate(Vector3.up, _cameraVelocity.x * sensitivity * Time.deltaTime);
        _xRotation -= _cameraVelocity.y * sensitivity * Time.deltaTime;
        _xRotation = Mathf.Clamp(_xRotation, -90, 80);
        camera.localRotation = Quaternion.Euler(_xRotation, 0, 0);
    }

    private void FixedUpdate()
    {
        _characterController.Move((transform.forward * _velocity.y + transform.right * _velocity.x) * _speed *Time.fixedDeltaTime);
        _characterController.Move(Vector3.up * _velocityY * Time.fixedDeltaTime);
    }

    private void UnListenInput()
    {
        _input.OnMoveEvent -= OnMove;
        _input.OnJumpEvent -= OnJump;
        _input.OnCameraEvent -= OnCamera;
        _input.OnRunEvent -= OnRun;
        _input.OnLookEvent -= OnLook;
    }

    private void OnDestroy()
    {
        UnListenInput();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(checkGround.position, checkGroundRadius);
    }
}
