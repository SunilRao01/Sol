using UnityEngine;
using System.Collections;

public class ShipAnimations : MonoBehaviour 
{
	private bool isRotating;

	void Start () 
	{
	
	}
	
	void Update () 
	{
		// Handle slide rotations when player moves
		if (Input.GetAxisRaw("Horizontal") > 0)
		{
			Vector3 newRotation = transform.eulerAngles;
			newRotation.z -= 25;

			if (!isRotating)
			{
				iTween.RotateTo(gameObject, iTween.Hash("rotation", newRotation, "time", 0.5f));
				isRotating = true;
			}
		}

		if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
		{
			if (isRotating)
			{
				iTween.RotateTo(gameObject, iTween.Hash("rotation", Vector3.zero, "time", 0.5f));
				//isRotating = false;
			}
		}
	}
}
