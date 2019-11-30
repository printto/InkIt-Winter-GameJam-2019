using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook
{
    private Camera m_playerCamera;
    private GameObject m_player;
    private float m_mouseSensitivity = 150f;

    private float xAxisClamp;

    public PlayerLook(GameObject player)
    {
        m_player = player;
        m_playerCamera = player.GetComponentInChildren<Camera>();
        xAxisClamp = 0.0f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * m_mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * m_mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;

        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseX = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }


        m_playerCamera.transform.Rotate(Vector3.left * mouseY);
        m_player.transform.Rotate(Vector3.up * mouseX);
    }
    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = m_playerCamera.transform.eulerAngles;
        eulerRotation.x = value;
        m_playerCamera.transform.eulerAngles = eulerRotation;
    }
}
