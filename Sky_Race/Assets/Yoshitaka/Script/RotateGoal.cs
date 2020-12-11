using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGoal : MonoBehaviour
{
    bool key;
    // Start is called before the first frame update
    void Start()
    {
        key = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (key == true)
        {
            if (transform.localEulerAngles.z <= 180 /*&& transform.localEulerAngles.z >= 170*/)
            {
                //回転させる角度
                float angle = -1;

                //カメラを回転させる
                transform.RotateAround(transform.position, Vector3.back, angle);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            key = true;
        }
    }
}
