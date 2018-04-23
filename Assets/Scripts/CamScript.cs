using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
	private Camera cam;

	public void SetBackgroundColor(Color color)
	{
		cam.backgroundColor = color;
	}
	void Awake()
	{
		cam = GetComponent<Camera>();
	}
	
	
}
