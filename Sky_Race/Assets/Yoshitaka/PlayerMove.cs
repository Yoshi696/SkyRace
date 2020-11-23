using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // private Rigidbody rb;
    // public float speed = 15f;
    // public float yoko = 0.5f;
    // public float zen = 0.05f;
    // //private Vector3 playerpos;

    //// public StartRun startrun;

    // private void Start()
    // {
    //     //    playerpos = transform.position;
    //     rb = GetComponent<Rigidbody>();



    // }

    // private void Update()
    // {
    //     //キーボード
    //     float velox = speed * Input.GetAxisRaw("Horizontal");
    //     float nox = speed * Input.GetAxisRaw("Vertical");

    //     float ang = 0.005f * Input.GetAxisRaw("Horizontal");

    //     float gen = Input.GetAxisRaw("Vertical");
    //     float rot = Input.GetAxisRaw("Horizontal");

    //     //↓前進
    //     Vector3 pos = this.gameObject.transform.localPosition;
    //     this.transform.localPosition = new Vector3(pos.x, pos.y, pos.z+zen);

    //     //↓前進
    //     //Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
    //     //Vector3 go = rb.position;
    //     //go += new Vector3(0, 0, 0.05f);
    //     //rb.position = go;

    //     //↓左右キーで回転
    //     if (rot == 1)
    //     {
    //         transform.Rotate(0, -50 * -ang, 0);
    //         this.transform.localPosition = new Vector3(pos.x+zen, pos.y, pos.z+zen);
    //     }
    //     else if (rot < 0)
    //     {
    //         transform.Rotate(0, -50 * -ang, 0);

    //     }

    //     //↓下キー入力で落下
    //     if (gen < 0)
    //     {
    //        GetComponent<Rigidbody>().velocity = new Vector3(0, nox, 0f + zen);
    //     }
    //     else
    //     {
    //         GetComponent<Rigidbody>().velocity = new Vector3(0, 0f, 0f + zen);
    //     }
    // }
    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.gameObject.tag == "Buns")
    //     {
    //         transform.Rotate(new Vector3(0, 180, 0));
    //         StartCoroutine("WaitKeyInput");
    //     }
    // }
    // IEnumerator WaitKeyInput()
    // {
    //     this.gameObject.GetComponent<PlayerMove>().enabled = false;
    //     {
    //         yield return new WaitForSeconds(1.0f);
    //     }
    //     this.gameObject.GetComponent<PlayerMove>().enabled = true;
    // }

    // private void FixedUpdate()
    // {

    // }

    //参考にしたサイト：https://htsuda.net/archives/1662

    public bool CanMove = true;
    public bool CanMoveForward = true;
    public bool CanMoveBack = true;
    public bool CanMoveLeft = true;
    public bool CanMoveRight = true;
    public bool CanMoveUp = true;
    public bool CanMoveDown = true;
    public bool CanRotateYaw = true;
    public bool CanRotatePitch = true;
    public bool CanRotateRoll = true;

    private float MovementSpeed;
    public float ControlSpeed = 500f;
    public float RotationSpeed = 100f;
    public StartRun startrun;
    public int karbspeed = 2;

    private bool canTranslate;
    private bool canRotate;

    private bool plus = false;
    private bool sita = false;


    private Rigidbody rB;

    public float jumpForce = 20.0f;
    private float turboForce = 1f;

    private int angCout1;

    private ParticleSystem Wind;
    private ParticleSystem Wind2;
    private ParticleSystem Wind3;

    void Start()
    {
        //動きに関しての情報
        canTranslate = CanRotateYaw || CanRotatePitch || CanRotateRoll;
        canRotate = CanMoveForward || CanMoveBack || CanMoveRight || CanMoveLeft || CanMoveUp || CanMoveDown;
        //重力取得
        rB = GetComponent<Rigidbody>();
        //助走から速度を持ってくる
        MovementSpeed = startrun.GetSpeedValue();
        MovementSpeed = MovementSpeed * ControlSpeed;
        //風のエフェクト取得
        Wind = GameObject.Find("wind").GetComponent<ParticleSystem>();
        Wind2 = GameObject.Find("windspeed").GetComponent<ParticleSystem>();
        Wind3 = GameObject.Find("wind (up)").GetComponent<ParticleSystem>();
        Wind.Play();
        Wind2.Stop();
        Wind3.Stop();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if (CanMove)
        {
            UpdatePosition();
        }
    }

    void UpdatePosition()
    {
        float gen = Input.GetAxisRaw("Vertical");
        float rot = Input.GetAxisRaw("Horizontal");
        float ang = Input.GetAxisRaw("Horizontal");
        /*Roll*/
        sita = true;

        //回転

        //現在は座標で直接計算しているが、変数を使ってできないか？（例えば変数に１足していって１５になったら回転やめるとか）
        //要検討

        if (canRotate)
        {
            Quaternion AddRot = Quaternion.identity;
            float yaw = 0;
            float pitch = 0;
            float roll = 0;
            //Debug.Log(yaw);

            //左右方向に回転・これを連動すればカーブいける！
            if (CanRotateYaw)
            {
                // yaw = Input.GetAxis("Yaw")/*これで回転しているからキーを変えてみる*/ * (Time.fixedDeltaTime * RotationSpeed);
                if (ang > 0)
                {
                    //yaw = 1;
                    AddRot.eulerAngles = new Vector3(0, 0.1f, 0);
                    GetComponent<Rigidbody>().rotation *= AddRot;
                }
                else if (ang < 0)
                {
                    //yaw = -1;
                    AddRot.eulerAngles = new Vector3(0, -0.1f, 0);
                    GetComponent<Rigidbody>().rotation *= AddRot;
                }
            }

            //下方向に向く　gen=0は押されていない　gen=1は上　gen=-1は↓
            if (gen == -1)
            {
                //if (sita == true)
                //{
                //    //pitch = Input.GetAxis("Pitch") * (Time.fixedDeltaTime * RotationSpeed);
                //    AddRot.eulerAngles = new Vector3(0.1f, 0, 0);
                //    GetComponent<Rigidbody>().rotation *= AddRot;
                //    plus = true;
                //}

                if (angCout1 >= 55 || transform.localEulerAngles.x <= 90 && transform.localEulerAngles.x >= 85/*transform.localEulerAngles.x <= 30 && transform.localEulerAngles.x >= 25*/)
                {
                    AddRot.eulerAngles = new Vector3(0, 0, 0);
                   // angCout1 = 0;
                }
                else
                {
                    AddRot.eulerAngles = new Vector3(0.5f, 0, 0);
                    GetComponent<Rigidbody>().rotation *= AddRot;
                    angCout1++;
                }

            }
            if (gen == 1)
            {
                //if (transform.localEulerAngles.x == 0 && transform.localEulerAngles.x <= 360 || transform.localEulerAngles.x >= 265 /*&& transform.localEulerAngles.x <= 1*/)
                //{
                //    plus = false;
                //}

                //if (plus == true)
                //{
                //    sita = false;
                //    AddRot.eulerAngles = new Vector3(-0.1f, 0, 0);
                //    GetComponent<Rigidbody>().rotation *= AddRot;
                //}

                if (transform.localEulerAngles.x <= 359 && transform.localEulerAngles.x >= 340)
                {
                    AddRot.eulerAngles = new Vector3(0, 0, 0);
                    //angCout1 = 0;
                }
                else
                {
                    AddRot.eulerAngles = new Vector3(-0.5f, 0, 0);
                    GetComponent<Rigidbody>().rotation *= AddRot;
                    angCout1--;
                }
            }
            /*else */
            if (gen == 0)
            {
                //if (transform.localEulerAngles.x == 0 && transform.localEulerAngles.x <= 360 || transform.localEulerAngles.x >= 265 /*&& transform.localEulerAngles.x <= 1*/)
                //{
                //    plus = false;
                //}

                if (transform.localEulerAngles.x <= 359 && transform.localEulerAngles.x >= 340)
                {
                    angCout1 = 0;
                }
                else
                {
                    sita = false;
                    AddRot.eulerAngles = new Vector3(-0.1f, 0, 0);
                    GetComponent<Rigidbody>().rotation *= AddRot;
                    angCout1--;
                }
            }

            //自分が横に傾く（傾くと変な動きするから傾きは別作った方がいいかも？）
            //if (CanRotateRoll)
            //{
            //    roll = Input.GetAxis("Roll") * (Time.fixedDeltaTime * RotationSpeed);
            //}

            if (CanRotateRoll)
            {
                if (ang > 0)
                {
                    if (transform.localEulerAngles.z <= 345 && transform.localEulerAngles.z >= 340)
                    {
                        AddRot.eulerAngles = new Vector3(0, 0, 0);
                    }
                    else
                    {
                        AddRot.eulerAngles = new Vector3(0, 0, -0.5f);
                        GetComponent<Rigidbody>().rotation *= AddRot;
                    }
                }
                else if (ang < 0)
                {
                    if (transform.localEulerAngles.z <= 20 && transform.localEulerAngles.z >= 15 /*&& transform.localEulerAngles.z >= 0*/)
                    {
                        AddRot.eulerAngles = new Vector3(0, 0, 0);
                    }
                    else
                    {
                        AddRot.eulerAngles = new Vector3(0, 0, 0.5f);
                        GetComponent<Rigidbody>().rotation *= AddRot;
                    }
                }
                else if (ang == 0)
                {
                    if (transform.localEulerAngles.z <= 20 && transform.localEulerAngles.z >= 0.5)
                    {
                        AddRot.eulerAngles = new Vector3(0, 0, -0.5f);
                        GetComponent<Rigidbody>().rotation *= AddRot;
                    }
                    if (transform.localEulerAngles.z <= 359.5 && transform.localEulerAngles.z >= 340)
                    {
                        AddRot.eulerAngles = new Vector3(0, 0, 0.5f);
                        GetComponent<Rigidbody>().rotation *= AddRot;
                    }

                }
            }

            //実際傾く所
            //AddRot.eulerAngles = new Vector3(-pitch, yaw, -roll);
            //GetComponent<Rigidbody>().rotation *= AddRot;
            float debug = transform.localEulerAngles.x;
            //Debug.Log(plus);
            //Debug.Log(debug);
            //Debug.Log(transform.localEulerAngles.z);
            //
            //if (sita == true)
            //{
            if (transform.localEulerAngles.x <= 15)
            {
                AddRot.eulerAngles = new Vector3(-pitch, yaw, -roll);
                GetComponent<Rigidbody>().rotation *= AddRot;
                sita = true;
            }
            else if (transform.localEulerAngles.x >= 350)
            {
                AddRot.eulerAngles = new Vector3(-pitch, yaw, -roll);
                GetComponent<Rigidbody>().rotation *= AddRot;
                sita = true;
            }

            //         else
            //         {
            //	AddRot.eulerAngles = new Vector3(-pitch, yaw, -roll);
            //	GetComponent<Rigidbody>().rotation *= AddRot;
            //	sita = true;
            //}
            //}
        }

        // 移動
        if (canTranslate)
        {
            // Check key input
            float[] input = new float[6]; // Forward, Back, Left, Right, Up, Down
                                          //↓前方
                                          //if (CanMoveForward && Input.GetKey(KeyCode.U))
                                          //{
            input[0] = 1;
            //}
            //↓後方
            //if (CanMoveBack && Input.GetKey(KeyCode.J))
            //{
            //	input[1] = 1;
            //}


            //カーブ
            if (rot == 1)
            {
                //↓左折
                if (CanMoveLeft && Input.GetKey(KeyCode.H))
                {
                    input[2] = 0.2f;
                }

            }
            else if (rot < 0)
            {
                //↓右折
                if (CanMoveRight && Input.GetKey(KeyCode.K))
                {
                    input[3] = 0.2f;
                }
            }
            ////↓左折
            //if (CanMoveLeft && Input.GetKey(KeyCode.H))
            //{
            //	input[2] = 1;
            //}
            ////↓右折
            //else if (CanMoveRight && Input.GetKey(KeyCode.K))
            //{
            //	input[3] = 1;
            //}
            //↓上昇
            //if (CanMoveUp && Input.GetKey(KeyCode.Y))
            //{
            //	input[4] = 1;
            //}

            //下キーで降下
            if (gen == 1)
            {
            }
            else if (gen < 0)
            {
                //↓下降
                //if (CanMoveDown && Input.GetKey(KeyCode.I))
                //{
                input[5] = 1;
                //}
            }

            ////↓下降
            //if (CanMoveDown && Input.GetKey(KeyCode.I))
            //{
            //    input[5] = 1;
            //}

            float numInput = 0;
            for (int i = 0; i < 6; i++)
            {
                numInput += input[i];
            }
            // 実際の動き
            float curSpeed = numInput > 0 ? MovementSpeed : 0;
            Vector3 AddPos = input[0] * turboForce * Vector3.forward + input[2] * Vector3.left + input[4] * Vector3.up
                + input[1] * Vector3.back + input[3] * Vector3.right /*+ input[5] * Vector3.down*/;
            AddPos = GetComponent<Rigidbody>().rotation * AddPos;

            GetComponent<Rigidbody>().velocity = AddPos * (Time.fixedDeltaTime * MovementSpeed);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Buns")
        {
            transform.Rotate(new Vector3(0, 180, 0));
            //StartCoroutine("WaitKeyInput");
        }

        if (other.gameObject.tag == "Over")
        {
            CanMove = false;
            CanMoveForward = false;
            CanMoveBack = false;
            CanMoveLeft = false;
            CanMoveRight = false;
            CanMoveUp = false;
            CanMoveDown = false;
            CanRotateYaw = false;
            CanRotatePitch = false;
            CanRotateRoll = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Jump")
        {
            StartCoroutine("WaitKeyInput1");
        }
        if (other.gameObject.tag == "Turbo")
        {
            StartCoroutine("WaitKeyInput2");
        }
    }

    IEnumerator WaitKeyInput1()
    {
        //this.gameObject.GetComponent<Renderer>().enabled = false;
        //{
        //    yield return new WaitForSeconds(1.0f);
        //}
        //this.gameObject.GetComponent<Renderer>().enabled = true;
        Wind.Stop();
        Wind3.Play();
        rB.AddForce(0, jumpForce, 0, ForceMode.Force);
        this.gameObject.GetComponent<PlayerMove>().enabled = false;
        this.gameObject.GetComponent<Gravity>().enabled = false;
        {
            yield return new WaitForSeconds(1.0f);
        }
        this.gameObject.GetComponent<Gravity>().enabled = true;
        this.gameObject.GetComponent<PlayerMove>().enabled = true;
        Wind3.Stop();
        Wind.Play();
    }

    IEnumerator WaitKeyInput2()
    {
        Wind.Stop();
        Wind2.Play();
        turboForce += 5f;
        yield return new WaitForSeconds(1.2f);
        turboForce -= 5f;
        Wind2.Stop();
        Wind.Play();

    }

    private void OnCollisionStay(Collision other)
    {//ゴールに接触している間徐々にスピードを下げる
        if (other.gameObject.tag == "Goal")
        {
            if (MovementSpeed >= 0)
            {
                MovementSpeed -= 5f;
                //Debug.Log(MovementSpeed);
            }
            Wind.Stop();
        }
    }
}
