using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform mainplayer;
	public float cameraLength = 30.0f;
	
	void Awake()
	{
		GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height/2) / cameraLength);
	}	
	
	void FixedUpdate()
	{
		transform.position = new Vector3(mainplayer.position.x, mainplayer.position.y, transform.position.z);
	}	
}
