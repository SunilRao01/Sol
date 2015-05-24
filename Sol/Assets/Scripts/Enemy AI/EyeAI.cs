using UnityEngine;
using System.Collections;

public class EyeAI : MonoBehaviour 
{
	private Transform playerTransform;

	void Start () 
	{
		playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	void Update () 
	{
		transform.LookAt(playerTransform.position);
	}
}
