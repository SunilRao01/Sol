﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RealtimeLines : MonoBehaviour 
{
	public List<Vector3> vertexList;
	public float lineDrawDelay;

	private int deleteCounter;
	public int deleteTime;
	public Color lineColor;

	void Start () 
	{
		vertexList.Add(transform.position);

		//StartCoroutine(waitThenVertex());
	}

	void Update()
	{
		vertexList.Add(transform.position);

		deleteCounter++;
		if (deleteCounter % deleteTime == 0)
		{
			vertexList.RemoveAt(0);
		}
	}

	void OnRenderObject()
	{
		GL.Begin(GL.LINES);
		GL.Color(lineColor);
		{
			for (int i = 0; i < vertexList.Count-1; i++)
			{
				GL.Vertex(vertexList[i]);
				GL.Vertex(vertexList[i+1]);
			}
		}
		GL.End();
	}

	IEnumerator waitThenVertex()
	{
		while (true)
		{
			yield return new WaitForSeconds(lineDrawDelay);

			vertexList.Add(transform.position);
		}
	}
}
