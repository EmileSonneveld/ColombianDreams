using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtrudePoint : MonoBehaviour
{
	public bool relative = true;
	//[Range(-0.4f, 0.4f)]
	[Range(0f, 1f)]
	public float uvoffset;

	public Vector3 pos
	{
		get
		{
			return this.transform.localPosition;
		}
		set
		{
			this.transform.localPosition = value;
		}
	}

	void Start()
	{

	}

	void Update()
	{

	}
}
