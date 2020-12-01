using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRotThird : MonoBehaviour
{
    Vector3 def;
    Vector3 _parent;

    void Awake()
    {
        def = transform.localRotation.eulerAngles;
        _parent = transform.parent.transform.localRotation.eulerAngles;
        _parent.x += 19.315f;
        _parent.y -= 49.397f;
        _parent.z += 13.848f;
    }

    void Update()
    {
        //Vector3 _parent = transform.parent.transform.localRotation.eulerAngles;

        //修正箇所
        transform.localRotation = Quaternion.Euler(/*def -*/ _parent);
    }


}