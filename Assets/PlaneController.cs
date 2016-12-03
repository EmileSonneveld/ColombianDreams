using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{

	private Rigidbody rb;
	public float force = 2;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		var f = new Vector3();
		if (Input.GetKey(KeyCode.W))
			f.z -= 1;
		if (Input.GetKey(KeyCode.S))
			f.z += 1;
		if (Input.GetKey(KeyCode.A))
			f.x += 1;
		if (Input.GetKey(KeyCode.D))
			f.x -= 1;

		rb.AddForce(f * force);


		if (Input.GetKeyDown(KeyCode.Space))
			rb.isKinematic = !rb.isKinematic;
	}
}
