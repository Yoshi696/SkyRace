using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRot : MonoBehaviour
{
	public GameObject objTarget;
	public Vector3 offset;

	void Start()
	{
		updatePostion();
	}

	void LateUpdate()
	{
		updatePostion();
	}

	void updatePostion()
	{
		Vector3 pos = objTarget.transform.localPosition;

		transform.localPosition = pos + offset;
	}

}
