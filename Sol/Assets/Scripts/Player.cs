using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public float movementForce;
	public float maxSpeed;

	void Start () 
	{
	
	}
	
	void Update () 
	{
		handleMovement();
	}

	void handleMovement()
	{
		if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
		{
			if (Input.GetAxisRaw("Horizontal") > 0)
			{
				GetComponent<Rigidbody>().AddForce(Vector3.right * movementForce);
			}

			if (Input.GetAxisRaw("Horizontal") < 0)
			{
				GetComponent<Rigidbody>().AddForce(-Vector3.right * movementForce);
			}

			if (Input.GetAxisRaw("Vertical") > 0)
			{
				GetComponent<Rigidbody>().AddForce(Vector3.up * movementForce);
			}

			if (Input.GetAxisRaw("Vertical") < 0)
			{
				GetComponent<Rigidbody>().AddForce(-Vector3.up * movementForce);
			}
		}
	}
}
