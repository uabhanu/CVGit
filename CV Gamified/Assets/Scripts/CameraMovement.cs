using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Camera m_camera;
    float m_currentX = 0f , m_currentY = 0f , m_distance = 10f , m_sensitivityX = 4f , m_sensitivityY = 1f;
    [SerializeField] float m_xAngleMax , m_xAngleMin , m_yAngleMax, m_yAngleMin;
    [SerializeField] Transform m_cameraTransform , m_lookAt;

    private void Start()
    {
        m_cameraTransform = transform;
        m_camera = Camera.main;
    }

    private void Update()
    {
        m_currentX += Input.GetAxis("Mouse X");
        m_currentY += Input.GetAxis("Mouse Y");

        m_currentX = Mathf.Clamp(m_currentX , m_xAngleMin , m_xAngleMax);
        m_currentY = Mathf.Clamp(m_currentY , m_yAngleMin , m_yAngleMax);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0f , 0f , -m_distance);
        Quaternion rotation = Quaternion.Euler(m_currentY , m_currentX , 0f);
        m_cameraTransform.position = m_lookAt.position + rotation * dir;
        m_cameraTransform.LookAt(m_lookAt.position);
    }
}
