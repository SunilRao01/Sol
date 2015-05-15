using UnityEngine;
using System.Collections;

public class Blockade : MonoBehaviour 
{
	public float maxSpeed;
	public float movementForce;


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		moveConstantly();
	}

	void moveConstantly()
	{
		if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
		{
			GetComponent<Rigidbody>().AddForce(-Vector3.forward * movementForce);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			other.GetComponent<Player>().healthValue--;
		}
	}
}
