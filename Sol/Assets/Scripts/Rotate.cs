using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public bool negative;
	public bool xDirection;
	public bool yDirection;
	public bool zDirection;

	public float rotationalSpeed;
	public bool randomRotationDirection;

	void Start () 
	{
		if (randomRotationDirection)
		{
			int choice = Random.Range(1, 3);

			if (choice == 1)
			{
				negative = true;
			}
			else
			{
				negative = false;
			}
		}
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
