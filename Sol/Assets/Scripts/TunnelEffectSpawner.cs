using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TunnelEffectSpawner : MonoBehaviour 
{
	public List<GameObject> tunnelEffects;

	public float minSpawnTime;
	public float maxSpawnTime;

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
			yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime + 1));

			int choice = Random.Range(0, tunnelEffects.Count);
			Instantiate(tunnelEffects[choice]);
		}
	}
}
