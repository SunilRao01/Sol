using UnityEngine;
using System.Collections;

public class TunnelPiece : MonoBehaviour 
{
	public float movementSpeed;

	public float minZScale;
	public float maxZScale;

	void Start () 
	{
		
	}
	
	void Update () 
	{
		transform.Translate(-Vector3.forward * movementSpeed);
	}
}
