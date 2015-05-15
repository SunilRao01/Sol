using UnityEngine;
using System.Collections;

public class Tunnel : MonoBehaviour {

	public float tunnelMovementSpeed;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*Vector2 textureOffset = GetComponent<Renderer>().material.GetTextureOffset("Offset");
		textureOffset.y -= tunnelMovementSpeed;
		GetComponent<Renderer>().material.SetTextureOffset("Offset", textureOffset);*/
	}
}
