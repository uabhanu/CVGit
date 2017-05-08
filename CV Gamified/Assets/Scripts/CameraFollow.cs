using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform m_playerPos;    

	private void Start ()
    {
     
    }
	
	private void Update ()
    {
		if(Time.timeScale == 0)
        {
            return;
        }
   
        transform.position = new Vector3(m_playerPos.transform.position.x , transform.position.y , m_playerPos.transform.position.z - 4f);
        
    }
}
