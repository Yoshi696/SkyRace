using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
	//　メインカメラ
	[SerializeField]
	private GameObject mainCamera;
	//　切り替える他のカメラ
	[SerializeField]
	private GameObject otherCamera;

    private void Start()
    {
		mainCamera.SetActive(!mainCamera.activeSelf);
		otherCamera.SetActive(otherCamera.activeSelf);
	}

 //   // Update is called once per frame
 //   void Update()
	//{
	//	mainCamera.SetActive(!mainCamera.activeSelf);
	//	otherCamera.SetActive(otherCamera.activeSelf);
	//}
}
