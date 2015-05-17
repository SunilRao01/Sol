using UnityEngine;
using System.Collections;

public class SpiralEffect : MonoBehaviour 
{
	private bool zPosition;
	private Vector3 objectPosition;
	public float rotationSpeed;
	public float movementSpeed;

	// Random rotation direction
	private bool negative;
	void Start()
	{
		// Random z rotation
		int randomZRotation = Random.Range(0, 361);

		Vector3 newRotation = transform.eulerAngles;
		newRotation.z = randomZRotation;
		transform.eulerAngles = newRotation;

		int choice = Random.Range(1, 3);
		if (choice == 2)
		{
			negative = true;
		}

		// Random rotation and movement speed upon instantion
		rotationSpeed = Random.Range(0.5f, rotationSpeed+3);
		movementSpeed = Random.Range(0.5f, movementSpeed+3);
	}

	void Update () 
	{
		if (negative)
		{
			transform.Rotate(-Vector3.forward * rotationSpeed);
		}
		else
		{
			transform.Rotate(Vector3.forward * rotationSpeed);
		}

		transform.Translate(-Vector3.forward * movementSpeed);
	}
}
