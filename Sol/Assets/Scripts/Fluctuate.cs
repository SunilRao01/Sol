using UnityEngine;
using System.Collections;

public class Fluctuate : MonoBehaviour 
{
	public float frequency;
	public float amplitude;

	void Start () 
	{
	
	}
	
	void Update () 
	{
		transform.position += amplitude*(Mathf.Sin(2*Mathf.PI*frequency*Time.time) - Mathf.Sin(2*Mathf.PI*frequency*(Time.time - Time.deltaTime)))*transform.up;
	}
}
