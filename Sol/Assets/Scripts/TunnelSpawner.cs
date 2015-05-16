using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TunnelSpawner : MonoBehaviour 
{
	public List<GameObject> tunnelPieces;

	void Start () 
	{
		Random.seed = (int)System.DateTime.Now.Ticks;
		int choice = Random.Range(1, tunnelPieces.Count+1);
		Vector3 objectScale;
		GameObject tempTunnelPiece;
		int zRotation;

		tempTunnelPiece = (GameObject) Instantiate(tunnelPieces[choice-1], transform.position, Quaternion.identity);

		// Randomize z-scale
		objectScale = tempTunnelPiece.transform.localScale;
		objectScale.z = Random.Range(tempTunnelPiece.GetComponent<TunnelPiece>().minZScale, tempTunnelPiece.GetComponent<TunnelPiece>().minZScale);
		tempTunnelPiece.transform.localScale = objectScale;

		// Randomize rotation
		tempTunnelPiece.transform.Rotate(new Vector3(0, 0, zRotation = Random.Range(0, 181)));

		Debug.Log("Choice: " + choice.ToString() + ", Rotation: " + zRotation);
	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("TunnelPiece"))
		{
			Random.seed = (int)System.DateTime.Now.Ticks;
			int choice = Random.Range(1, tunnelPieces.Count+1);
			Vector3 objectScale;
			GameObject tempTunnelPiece;
			int zRotation;

			tempTunnelPiece = (GameObject) Instantiate(tunnelPieces[choice-1], transform.position, Quaternion.identity);

			// Randomize z-scale
			objectScale = tempTunnelPiece.transform.localScale;
			objectScale.z = Random.Range(tempTunnelPiece.GetComponent<TunnelPiece>().minZScale, tempTunnelPiece.GetComponent<TunnelPiece>().minZScale);
			tempTunnelPiece.transform.localScale = objectScale;

			// Randomize rotation
			tempTunnelPiece.transform.Rotate(new Vector3(0, 0, zRotation = Random.Range(0, 181)));

			Debug.Log("Choice: " + choice.ToString() + ", Rotation: " + zRotation.ToString());
		}
	}
}
