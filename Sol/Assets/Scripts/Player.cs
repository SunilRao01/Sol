using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{
	public float movementForce;
	public float maxSpeed;

	public int healthValue;
	public Text healthLabel;

	void Start () 
	{
	
	}
	
	void Update () 
	{
		// Keep health label updated
		healthLabel.text = healthValue.ToString();

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
