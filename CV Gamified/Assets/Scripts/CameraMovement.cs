using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
	
	void Update()
    {
        //transform.LookAt(playerTransform.position);
        transform.position = new Vector3(playerTransform.position.x , playerTransform.position.y + 1.48f , playerTransform.position.z - 4f);
	}
}
