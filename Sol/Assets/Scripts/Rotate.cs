﻿using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public bool xDirection;
	public bool yDirection;
	public bool zDirection;

	public float rotationalSpeed;

	void Start () 
	{
	
	}
	
	void Update () 
	{
		if (xDirection)
		{
			transform.Rotate(Vector3.right * rotationalSpeed);
		}
		else if (yDirection)
		{
			transform.Rotate(Vector3.up * rotationalSpeed);
		}
		else if (zDirection)
		{
			transform.Rotate(Vector3.forward * rotationalSpeed);
		}
	}
}
