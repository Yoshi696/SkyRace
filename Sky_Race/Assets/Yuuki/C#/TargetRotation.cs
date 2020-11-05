using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotation : MonoBehaviour
{

    public float rotAngle = 100f;
    public GameObject centerObj;
    private Vector3 targetPos;

    void Start()
    {
        targetPos = centerObj.transform.position;
    }

    //void Update()
    //{
    //    Transform centerObj = GameObject.Find("Uturn").transform;
    //    targetPos = centerObj.transform.position;
    //    transform.RotateAround(targetPos, Vector3.up, rotAngle * Time.deltaTime);
    //}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "bunc")
        {
            Transform centerObj = GameObject.Find("Uturn").transform;
            targetPos = centerObj.transform.position;
            transform.RotateAround(targetPos, Vector3.up, rotAngle * Time.deltaTime);
        }
    }
}
