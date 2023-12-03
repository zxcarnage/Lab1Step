﻿using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float _topBorder;
    [SerializeField] private float _bottomBorder;
    [SerializeField] private float _sensitivity;

    private float _currentVerticalRotation;
    private float _currentHorizontalRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Mouse X") * _sensitivity * Time.deltaTime;
        float vertical = Input.GetAxis("Mouse Y") * _sensitivity * Time.deltaTime;
        TryRotate(horizontal, vertical);
    }

    private void TryRotate(float horizontal, float vertical)
    {
        _currentHorizontalRotation += horizontal;
        _currentVerticalRotation = Mathf.Clamp(_currentVerticalRotation + vertical, _bottomBorder, _topBorder);
        transform.localRotation = Quaternion.Euler(new Vector3(-_currentVerticalRotation,_currentHorizontalRotation,0));
    }
}