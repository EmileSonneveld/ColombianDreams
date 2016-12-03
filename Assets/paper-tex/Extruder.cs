using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extruder : MonoBehaviour
{
	private Mesh mesh;
	public Vector3 direction = new Vector3(20, 0, 0);
	public float scaleUv = 1;
	public float borderUv
	{
		get
		{
			return direction.magnitude * scaleUv;
		}
	}

	public ExtrudePoint[] points
	{
		get { return this.GetComponentsInChildren<ExtrudePoint>(); }
	}

	void Awake()
	{
		mesh = GetComponent<MeshFilter>().sharedMesh;
		if (mesh == null)
			mesh = GetComponent<MeshFilter>().mesh;


		//transform.position = Vector3.zero;
	}

	void Start()
	{
		UpdateMesh();
		GenerateIndices();
		UpdateUv();
		mesh.RecalculateBounds();
	}

	void GenerateIndices()
	{
		List<int> indices = new List<int>(mesh.vertices.Length * 3);
		for (int i = 0; i < mesh.vertices.Length - 2; i += 2)
		{

			indices.Add(i + 0);
			indices.Add(i + 1);
			indices.Add(i + 2);

			indices.Add(i + 1);
			indices.Add(i + 3);
			indices.Add(i + 2);
		}
		mesh.SetIndices(indices.ToArray(), MeshTopology.Triangles, 0);
	}


	private void UpdateUv()
	{
		var uv = new Vector2[mesh.vertices.Length];
		for (int i = 0; i < mesh.vertices.Length; i += 2)
		{
			var p = points[i / 2];
			if (p.relative)
			{
				uv[i + 0] = new Vector2(0 + borderUv, Mathf.Floor(i / 2f) / (((float)mesh.vertices.Length - 2) / 2f) + p.uvoffset);
				uv[i + 1] = new Vector2(1 - borderUv, Mathf.Floor(i / 2f) / (((float)mesh.vertices.Length - 2) / 2f) + p.uvoffset);
			}
			else
			{
				uv[i + 0] = new Vector2(0 + borderUv, points[i / 2].uvoffset);
				uv[i + 1] = new Vector2(1 - borderUv, points[i / 2].uvoffset);
			}
		}
		mesh.uv = uv;
	}

	private void UpdateMesh()
	{
		var tmp = new Vector3[points.Length * 2];
		for (int i = 0; i < points.Length; i++)
		{
			tmp[i * 2] = points[i].pos;
			tmp[i * 2 + 1] = points[i].pos + this.direction;
		}
		mesh.vertices = tmp;
	}


	public bool needUpdate = true;

	void OnDrawGizmos()
	{
		if (!needUpdate) return;
		needUpdate = false;

		if (Application.isEditor)
		{
			Awake();
		}
		UpdateMesh();
		GenerateIndices();
		UpdateUv();
		mesh.RecalculateBounds();
		/*for (int i = 0; i < points.Length - 1; i += 2)
		{
			Gizmos.DrawLine(points[i].pos, points[i + 1].pos);
		}*/
	}
}
