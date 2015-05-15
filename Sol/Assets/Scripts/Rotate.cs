using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public bool negative;
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
			if (negative)
			{
				transform.Rotate(-Vector3.right * rotationalSpeed);
			}
			else
			{
				transform.Rotate(Vector3.right * rotationalSpeed);
			}
		}
		if (yDirection)
		{
			if (negative)
			{
				transform.Rotate(-Vector3.up * rotationalSpeed);
			}
			else
			{
				transform.Rotate(Vector3.up * rotationalSpeed);
			}
		}
		if (zDirection)
		{
			if (negative)
			{
				transform.Rotate(-Vector3.forward * rotationalSpeed);
			}
			else
			{
				transform.Rotate(Vector3.forward * rotationalSpeed);
			}
		}
	}
}
