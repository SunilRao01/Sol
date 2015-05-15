using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TunnelSpawner : MonoBehaviour 
{
	public List<GameObject> tunnelPieces;

	public float minZScale;
	public float maxZScale;

	void Start () 
	{
		Random.seed = (int)System.DateTime.Now.Ticks;
		int choice = Random.Range(1, 3);
		Vector3 objectScale;
		GameObject tempTunnelPiece;

		if (choice == 1)
		{
			tempTunnelPiece = (GameObject) Instantiate(tunnelPieces[0], transform.position, Quaternion.identity);
		}
		else 
		{
			tempTunnelPiece = (GameObject) Instantiate(tunnelPieces[1], transform.position, Quaternion.identity);
		}

		// Randomize z-scale
		objectScale = tempTunnelPiece.transform.localScale;
		objectScale.z = Random.Range(minZScale, maxZScale);
		tempTunnelPiece.transform.localScale = objectScale;

		// Randomize rotation
		tempTunnelPiece.transform.Rotate(new Vector3(0, 0, Random.Range(0, 361)));

		Debug.Log("Choice: " + choice.ToString());
	}

	// z-scale range: 10-150

	void Update () 
	{

			
	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("TunnelPiece"))
		{
			Random.seed = (int)System.DateTime.Now.Ticks;
			int choice = Random.Range(1, 3);
			Vector3 objectScale;
			GameObject tempTunnelPiece;
			
			if (choice == 1)
			{
				tempTunnelPiece = (GameObject) Instantiate(tunnelPieces[0], transform.position, Quaternion.identity);
			}
			else
			{
				tempTunnelPiece = (GameObject) Instantiate(tunnelPieces[1], transform.position, Quaternion.identity);
			}

			// Randomize z-scale
			objectScale = tempTunnelPiece.transform.localScale;
			objectScale.z = Random.Range(minZScale, maxZScale);
			tempTunnelPiece.transform.localScale = objectScale;

			// Randomize rotation
			tempTunnelPiece.transform.Rotate(new Vector3(0, 0, Random.Range(0, 361)));

			Debug.Log("Choice: " + choice.ToString());
		}
	}
}
