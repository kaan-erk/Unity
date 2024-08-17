using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;

public class KeyPressCooldown : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.Space;
    public Transform newCameraPosition;
    public float cooldownTime = 1f;

    private Vector3 defaultPosition;
    private Quaternion defaultRotation;
    private bool isPositionChanged = false;
    private bool isOnCooldown = false;
    private float cooldownEndTime;

    private void Start()
    {
        defaultPosition = Camera.main.transform.position;
        defaultRotation = Camera.main.transform.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey) && !isOnCooldown)
        {
            ToggleCameraPosition();
            StartCooldown();
        }

        UpdateCooldown();
    }

    private void ToggleCameraPosition()
    {
        if (isPositionChanged)
        {
            Camera.main.transform.position = defaultPosition;
            Camera.main.transform.rotation = defaultRotation;
        }
        else
        {
            if (newCameraPosition != null)
            {
                Camera.main.transform.position = newCameraPosition.position;
                Camera.main.transform.rotation = newCameraPosition.rotation;
            }
        }

        isPositionChanged = !isPositionChanged;
    }

    private void StartCooldown()
    {
        isOnCooldown = true;
        cooldownEndTime = Time.time + cooldownTime;
    }

    private void UpdateCooldown()
    {
        if (isOnCooldown && Time.time >= cooldownEndTime)
        {
            isOnCooldown = false;
        }
    }
}