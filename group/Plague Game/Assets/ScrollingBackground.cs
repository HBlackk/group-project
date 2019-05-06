using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
	public float size;
    private Transform cameraTransform;
	private Transform[] no_of_layers;
	private float view = 10;
	private int left;
	private int right;	
	
	public float speed;
	private float camerapos;
	
	
	private void Start()
	{
		
		cameraTransform = Camera.main.transform;
		camerapos = cameraTransform.position.x;
		no_of_layers = new Transform[transform.childCount];
		
		for(int i=0; i<transform.childCount; i++)		
			no_of_layers[i] = transform.GetChild(i);
		
		
		left = 0;
		right = no_of_layers.Length-1;		
	}	
	
	private void Update()
	{
		float x2 = cameraTransform.position.x - camerapos;
		transform.position += Vector3.right * (x2 * speed);
		camerapos = cameraTransform.position.x;
		if(cameraTransform.position.x < (no_of_layers[left].transform.position.x + view))
			ScrollLeft();
		
		if(cameraTransform.position.x > (no_of_layers[right].transform.position.x - view))
			ScrollRight();
	}	
	
	private void ScrollRight()
	{
		int finalleft = left;
		no_of_layers[right].position = Vector3.right * (no_of_layers[right].position.x + size);
		right = left;
		left = left + 1;
		
		if(left == no_of_layers.Length)		
			left = 0;		
	}
	
	private void ScrollLeft()
	{
		int finalright = right;
		no_of_layers[right].position = Vector3.right * (no_of_layers[left].position.x - size);
		left = right;
		right = right - 1;
		
		if(right < 0)		
			right = no_of_layers.Length-1;
				
	}	
}
