using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterPosition : MonoBehaviour
{

    void FixedUpdate()
    {
        GameObject playerObj = GameObject.Find("Player");
        if (playerObj != null)
        {
            transform.position = playerObj.transform.position;
        }

        if (playerObj == null)
        {
            Destroy(this.gameObject);
        }
    }
}
