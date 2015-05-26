using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TunnelEffectSpawner : Dancer 
{
	public List<GameObject> tunnelEffects;

	public float minSpawnTime;
	public float maxSpawnTime;

	// DANCE
	public override void dance (bool results)
	{
		

		if (results)
		{
			//spawnEffect();
		}

	} 

	void Start () 
	{
		StartCoroutine(waitAndSpawn());
		//segment = 2;
		init();
	}
	
	void Update () 
	{

	}

	void spawnEffect()
	{
		int choice = Random.Range(0, tunnelEffects.Count);
		Instantiate(tunnelEffects[choice]);
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
