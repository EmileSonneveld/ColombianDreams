using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orphanise : MonoBehaviour
{

	void Start()
	{
		this.transform.parent = null;
	}

	void Update()
	{

	}
}
