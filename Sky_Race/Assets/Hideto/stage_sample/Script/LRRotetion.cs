using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRRotetion : MonoBehaviour
{
    private float i = 0;
    private Vector3 a;
    private Vector3 pos;
    private Transform myObj;

    private int cp = 0;   // 0:当たっていない　1:左  2:右

    IEnumerator RotoR()
    {
        i = a.y;
        if (i < 90 && i >= 0)
        {// 真横から奥の方向を向いているとき
            i = i * -1f;
            yield return new WaitForSeconds(0.0001f);
            transform.rotation = Quaternion.Euler(a.x, i, a.z);

        }
        else if (i < 180 && i >= 90)
        {// 真横からスタートの方を向いているとき
            i = i * -1f;
            yield return new WaitForSeconds(0.0001f);
            transform.rotation = Quaternion.Euler(a.x, i, a.z);
        }

        for (int c = 0; c < 10; c++)
        {
            pos.x += -0.01f;// ここでも位置の調整
        }


    }

    IEnumerator RotoL()
    {
        i = a.y;

        if (i > 270 && i <= 360)
        {// 真横から奥の方向を向いているとき
            i = i * -1f;
            yield return new WaitForSeconds(0.0001f);
            transform.rotation = Quaternion.Euler(a.x, i, a.z);
        }
        else if (i > 180 && i <= 270)
        {// 真横からスタートの方を向いているとき
            i = i * -1f;
            yield return new WaitForSeconds(0.0001f);
            transform.rotation = Quaternion.Euler(a.x, i, a.z);

        }
        for (int c = 0; c < 10; c++)
        {
            pos.x -= -0.01f;// ここでも位置の調整
        }

    }

    IEnumerator Cpchange()
    {

        yield return new WaitForSeconds(2f);
        cp = 0;
    }
    IEnumerator GetPos()
    {

        yield return new WaitForSeconds(0.1f);

    }
    private void Update()
    {
        a = gameObject.transform.localEulerAngles;
        myObj = gameObject.transform;
        pos = myObj.transform.position;
        Debug.Log(cp);

        if (cp == 0)
        {
        }
        else if (cp == 1)
        {
            StartCoroutine("GetPos");// 空白の時間
            StartCoroutine("RotoL");// 向きと移動の調整
            transform.position = new Vector3(pos.x + 0.1f, pos.y, pos.z);// 移動はここで
            StartCoroutine("Cpchange");// 移動を終える

        }
        else if (cp == 2)
        {
            StartCoroutine("GetPos");// 空白の時間
            StartCoroutine("RotoR");// 向きの移動の調整
            transform.position = new Vector3(pos.x - 0.1f, pos.y, pos.z);// 移動はここで
            StartCoroutine("Cpchange");// 移動を終える
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (cp == 0)
        {
            if (other.gameObject.tag == "OverR")
            {
                cp = 2;

            }
            if (other.gameObject.tag == "OverL")
            {
                cp = 1;
            }
        }

    }
}
