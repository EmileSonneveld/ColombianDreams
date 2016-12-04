using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
	public Camera cameraUi;
	public Camera cameraFree;
	private Camera targetCamera;
	private Camera cam;

	public GameObject[] activeStanding = new GameObject[0];
	public GameObject[] activeSitting = new GameObject[0];

	void Awake()
	{
		cam = this.GetComponentInChildren<Camera>();
	}

	void Start()
	{
		ActivateSitting();
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

	public void ActivateSitting()
	{
		foreach (var go in activeStanding)
			if (go != null)
				go.SetActive(false);
		foreach (var go in activeSitting)
			if (go != null)
				go.SetActive(true);
	}

	public void ActivateStanding()
	{
		foreach (var go in activeStanding)
			if (go != null)
				go.SetActive(true);
		foreach (var go in activeSitting)
			if (go != null)
				go.SetActive(false);
	}

}
