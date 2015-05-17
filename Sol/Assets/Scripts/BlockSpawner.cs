using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlockSpawner : MonoBehaviour 
{
	public List<GameObject> blocks;

	public float minSpawnInterval;
	public float maxSpawnInterval;

	void Start () 
	{
		StartCoroutine(waitAndSpawn());
	}
	
	void Update () 
	{
		
	}

	IEnumerator waitAndSpawn()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));

			int choice = Random.Range(1, blocks.Count+1);

			GameObject tempBlock = (GameObject) Instantiate(blocks[choice-1], blocks[choice-1].transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
			tempBlock.transform.Rotate(0, Random.Range(0, 360), 0);

		}
	}
}
