using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatPrefab : MonoBehaviour
{
    public GameObject cloud;

    private int CreatTime;
    private int intvalTime = 500;

    // Update is called once per frame
    void Update()
    {

        if (CreatTime % intvalTime == 0)
        {
            CreatCloud();
            CreatTime = 1;
        }
        CreatTime += 1;

    }

    public void CreatCloud()
    {
       // Debug.Log("yers");
        GameObject newCloud = Instantiate(cloud, transform.position, transform.rotation);

        //Vector3 dir = cloud.transform.position;
        //cloud.transform.position = new Vector3(dir.x, dir.y, dir.z + 100);
        Vector3 dir = newCloud.transform.forward;

        newCloud.GetComponent<Rigidbody>().AddForce(dir * -10f, ForceMode.Impulse);

        newCloud.name = cloud.name;
        Destroy(newCloud, 20.0f);
    }
}
