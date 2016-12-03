using System;
using UnityEngine;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ConfigConfigJoint : MonoBehaviour
{
	public ConfigConfigJoint parent;
	private float prev_targetAngle = float.NaN;
	public float targetAngle = 0;
	private float prev_force = float.NaN;
	public float force = 20;
	private ConfigurableJoint joint;

	void Reset()
	{
		if (!joint)
			joint = GetComponent<ConfigurableJoint>();
		if (parent == null && joint.connectedBody)
			parent = joint.connectedBody.GetComponent<ConfigConfigJoint>();

	}

	[UsedImplicitly]
	void Awake()
	{
		if (!joint)
			joint = GetComponent<ConfigurableJoint>();

	}

	void Start()
	{
		ProbagateSettings();
	}

	[UsedImplicitly]
	void Update()
	{
		if (Time.frameCount % 10 != 0) return;
		ProbagateSettings();
	}

	void ProbagateSettings()
	{

		if (prev_targetAngle != targetAngle)
		{
			prev_targetAngle = targetAngle;
			joint.targetRotation = Quaternion.Euler(new Vector3(targetAngle, 0, 0));
		}
		if (prev_force != force)
		{
			prev_force = force;
			var drive = joint.angularXDrive;
			drive.positionSpring = force;
			joint.angularXDrive = drive;
		}
	}

	[UsedImplicitly]
	void OnDrawGizmos()
	{
		if (!joint)
			joint = GetComponent<ConfigurableJoint>();
		if (joint.connectedBody)
		{
			/*var root = (Vector3)(transform.localToWorldMatrix * joint.anchor) + transform.position;
			

			Gizmos.color = Color.red;
			Gizmos.DrawLine(root,  (Quaternion.Euler(targetAngle, 0, 0) * new Vector3(1, 0, 0)));
			Gizmos.color = Color.green;
			Gizmos.DrawLine(root,  ( Quaternion.Euler(new Vector3(targetAngle, 0, 0)) * new Vector3(0, 1, 0)));
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(root,  ( Quaternion.Euler(new Vector3(targetAngle, 0, 0)) * new Vector3(0, 0, 1)));*/
			/*
			Gizmos.color = Color.red;
			Gizmos.DrawRay(root, joint.connectedBody.transform.localToWorldMatrix * (Quaternion.Euler(new Vector3(0, targetAngle, 0)) * new Vector3(1, 0, 0)));
			Gizmos.color = Color.green;
			Gizmos.DrawRay(root, joint.connectedBody.transform.localToWorldMatrix * (Quaternion.Euler(new Vector3(0, targetAngle, 0)) * new Vector3(0, 1, 0)));
			Gizmos.color = Color.blue;
			Gizmos.DrawRay(root, joint.connectedBody.transform.localToWorldMatrix * (Quaternion.Euler(new Vector3(0, targetAngle, 0)) * new Vector3(0, 0, 1)));
			*/
		}
	}
}
