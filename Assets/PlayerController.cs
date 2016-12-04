using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
	public Camera cameraUi;
	public Camera cameraFree;
	private Camera targetCamera;
	private Camera cam;
	void Start()
	{
		cam = this.GetComponentInChildren<Camera>();
	}

	void Update()
	{
		if (targetCamera)
		{
			cam.fieldOfView += (targetCamera.fieldOfView - cam.fieldOfView) * 0.1f;
			cam.transform.position = Vector3.Lerp(cam.transform.position, targetCamera.transform.position, 0.1f);
			cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, targetCamera.transform.rotation, 0.1f);
		}
	}

	public void TargetUi()
	{
		targetCamera = cameraUi;
	}

	public void TargetFree()
	{
		targetCamera = cameraFree;
	}

}
