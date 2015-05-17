using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RealtimeLines : MonoBehaviour 
{
	public List<Vector3> vertexList;
	public float lineDrawDelay;

	void Start () 
	{
		vertexList.Add(transform.position);

		StartCoroutine(waitThenVertex());
	}

	void OnRenderObject()
	{
		GL.Begin(GL.LINES);
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

			Vector3 newLineVertex;
			newLineVertex.x = transform.position.x - vertexList[vertexList.Count-1].x;
			newLineVertex.y = transform.position.y - vertexList[vertexList.Count-1].y;
			newLineVertex.z = transform.position.z - vertexList[vertexList.Count-1].z;
			vertexList.Add(transform.position);
		}
	}
}
