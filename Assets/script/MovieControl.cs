﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovieControl : MonoBehaviour
{

#if EDITOR
	public MovieTexture movTexture = null;

	void Start()
	{
		//Debug.Log(JsonUtility.ToJson(new stuff()));
		//var deserialised = JsonUtility.FromJson<stuff>("{\"test\":0,\"integer\":108}");

		GetComponent<Renderer>().material.mainTexture = movTexture;
		movTexture.Play();
	}
#endif
	void Update()
	{

	}
}
