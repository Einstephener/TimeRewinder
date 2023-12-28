using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private Vector2 curMovementInput;
    public float jumpForce;
    public LayerMask groundLayerMask;

    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    public float lookSensitivity;

    private Vector2 mouseDelta;

    [HideInInspector]
    public bool canLook = true;

    private bool settingOn;

    private Rigidbody _rigidbody;

    public static PlayerController instance;
    private void Awake()
    {
        instance = this;
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //1인칭 화면에서 마우스 커서 숨기기
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate() //카메라 작업에 주로 쓰임
    {
        if (canLook)
        {
            CameraLook();
        }
    }

    private void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = _rigidbody.velocity.y;

        _rigidbody.velocity = dir;
    }

    void CameraLook() //카메라를 마우스로 움직일 수 있게 하는 것.
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    public void OnLookInput(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (IsGrounded())
                _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);

        }
    }

    private bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (Vector3.up * 0.01f) , Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f)+ (Vector3.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (Vector3.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (Vector3.up * 0.01f), Vector3.down),
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, groundLayerMask))
            {
                return true;
            }
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + (transform.forward * 0.2f), Vector3.down);
        Gizmos.DrawRay(transform.position + (-transform.forward * 0.2f), Vector3.down);
        Gizmos.DrawRay(transform.position + (transform.right * 0.2f), Vector3.down);
        Gizmos.DrawRay(transform.position + (-transform.right * 0.2f), Vector3.down);
    }

    public void ToggleCursor(bool toggle)
    {
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        canLook = !toggle;
    }   
    public void OnPhoneInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (!RecordManager.instance.isPhoneOpen)
            {
                RecordManager.instance.isPhoneOpen = true;
                RecordManager.instance.animator.SetTrigger("IsOpen");
            }
            else if (RecordManager.instance.isPhoneOpen)
            {
                RecordManager.instance.isPhoneOpen = false;
                RecordManager.instance.animator.SetBool("PhoneON", false);
                RecordManager.instance.animator.SetTrigger("IsClose");
            }

        }
    }
    public void OnRecordInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (RecordManager.instance.isPhoneOpen)
            {
                if (!RecordManager.instance.isRecording)
                {
                    RecordManager.instance.isRecording = true;

                }

                else if (RecordManager.instance.isRecording)
                {
                    RecordManager.instance.isRecording = false;
                }
            }
            else return;

        }
    }
    public void OnRewindInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (RecordManager.instance.isPhoneOpen)
            {
                if (RecordManager.instance.isRewinding)
                {
                    RecordManager.instance.StopRewind();
                }
                else 
                {
                    RecordManager.instance.StartRewind();
                }
            }
            else return;

        }
    }
    public void OnSettingInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (!settingOn)
            {
                UIManager.instance.HowToPlayPanel.SetActive(true);
                UIManager.instance.InGamePanel.SetActive(false);
                ToggleCursor(true);
                settingOn = true;
                Time.timeScale = 0f;
            }
            else
            {
                UIManager.instance.HowToPlayPanel.SetActive(false);
                UIManager.instance.InGamePanel.SetActive(true);
                ToggleCursor(false);
                settingOn = false;
                Time.timeScale = 1f;
            }
        }
        
    }
}