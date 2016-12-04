using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;

public class ActionController : MonoBehaviour
{
	private Vector3 origPos;

	//public UnityEvent onClick;

	void Start()
	{
		origPos = transform.localPosition;
	}

	void Update()
	{
		var tmp = origPos;
		tmp.y += Mathf.Sin(Time.time * 2) * 0.2f;
		transform.localPosition = tmp;
	}

	void OnMouseDown()
	{
		Debug.Log("Clicked: " + this.name);
		//onClick.Invoke();
	}
}
