using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float m_currentX = 0f , m_currentY = 0f;
    [SerializeField] float m_xAngleMax , m_xAngleMin , m_yAngleMax , m_yAngleMin , m_distance;
    [SerializeField] Transform m_playerTransform;

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
        transform.position = m_playerTransform.position + rotation * dir;
        transform.LookAt(m_playerTransform.position);
    }
}
