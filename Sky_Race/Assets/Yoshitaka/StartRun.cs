using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class StartRun : MonoBehaviour
{
    private Rigidbody rb;

    private float run = 0;
    public float plus = 0.0001f;
    public float jumpForce = 40f;
    private bool Button = false;
   // private bool JumoB = false;
    //Vector3 jump1 = new Vector3(0, 0, 0);
    //Vector3 jump2 = new Vector3(0, 0, 0);

    private ParticleSystem Wind;
    private ParticleSystem Wind2;
    private ParticleSystem Wind3;



    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        Wind = GameObject.Find("wind").GetComponent<ParticleSystem>();
        Wind2 = GameObject.Find("windspeed").GetComponent<ParticleSystem>();
        Wind3 = GameObject.Find("wind (up)").GetComponent<ParticleSystem>();
        Wind.Stop();
        Wind2.Stop();
        Wind3.Stop();
    }

    private void OnTriggerExit(Collider other)
    {
        ////↓ジャンプ
        //Vector3 _this = this.gameObject.transform.position;
        //if (Input.GetKeyUp(KeyCode.Z))
        //{
        if (other.gameObject.tag == "JosouJ")
        {
            //rb.velocity = Vector3.up * jumpForce;
            //JumoB = true;
            GetComponent<StartRun>().enabled = false;
            GetComponent<PlayerMove>().enabled = true;
            GetComponent<Gravity>().enabled = false;
            GetComponent<Result>().enabled = true;
        }
        //}
    }

    public float GetSpeedValue()
    {
        return run;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.gameObject.transform.position;//座標取得
        this.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z + run);//助走（前進）

        //↓助走中
        if (Input.GetButtonDown("Action") == true)
        {
            Button = true;
        }
        if (Input.GetButtonUp("Action") == true)
        {
            Button = false;
        }
        if(Button == true)
        {
            run = run + plus;
        }

        ////↓ジャンプの最高地点に到達したらスクリプトを切り替える
        //if (JumoB == true)
        //{
        //    jump1 = this.gameObject.transform.position;
        //}

        //if (jump1.y < jump2.y)
        //{
        //    GetComponent<StartRun>().enabled = false;
        //    GetComponent<PlayerMove>().enabled = true;
        //}

        //if (JumoB == true)
        //{
        //    jump2 = this.gameObject.transform.position;
        //}
    }
}
