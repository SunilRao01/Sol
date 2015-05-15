using UnityEngine;
using System.Collections;

public class TunnelPiece : MonoBehaviour 
{
	public float movementSpeed;

	void Start () 
	{
		
	}
	
	void Update () 
	{
		transform.Translate(-Vector3.forward * movementSpeed);
	}
}
