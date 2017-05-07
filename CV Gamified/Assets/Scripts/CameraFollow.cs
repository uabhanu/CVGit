using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float m_xOffset , m_zOffset;
    Rigidbody m_cameraBody;
    [SerializeField] Transform m_playerPos;    

	private void Start ()
    {
        m_cameraBody = GetComponent<Rigidbody>();
    }
	
	private void Update ()
    {
		if(Time.timeScale == 0)
        {
            return;
        }

        m_xOffset = m_playerPos.transform.position.x;
        m_zOffset = m_playerPos.transform.position.z - 4f;

        
        m_cameraBody.position = new Vector3(m_playerPos.transform.position.x , 0f , m_playerPos.transform.position.z - 4f);
        
    }
}
