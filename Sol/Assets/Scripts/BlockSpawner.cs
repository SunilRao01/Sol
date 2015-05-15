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
			int choice = Random.Range(1, 3);

			if (choice == 1)
			{
				GameObject tempBlock = (GameObject) Instantiate(blocks[0], blocks[0].transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
				tempBlock.transform.Rotate(0, Random.Range(0, 360), 0);
			}
			else if (choice == 2)
			{
				GameObject tempBlock = (GameObject) Instantiate(blocks[1], blocks[1].transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
				tempBlock.transform.Rotate(0, Random.Range(0, 360), 0);
			}

			yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
		}
	}
}
