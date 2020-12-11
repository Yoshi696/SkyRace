using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    //参考にしたサイト：https://htsuda.net/archives/1662

    private bool CanMove = true;
    private bool CanMoveForward = true;
    private bool CanMoveBack = true;
    private bool CanMoveLeft = true;
    private bool CanMoveRight = true;
    private bool CanMoveUp = true;
    private bool CanMoveDown = true;
    private bool CanRotateYaw = true;
    private bool CanRotatePitch = true;
    private bool CanRotateRoll = true;

    private float MovementSpeed;
    public float ControlSpeed = 500f;
   // public float RotationSpeed = 100f;
    public StartRun startrun;
   // public int karbspeed = 2;
    public int Item;                            //
    public GameObject ItemPrefab;               //アイテム化に必要なもの
    public Vector3 offset = new Vector3();      //
    public Quaternion onset = new Quaternion();

    private bool canTranslate;
    private bool canRotate;
    private bool isSETHI = true;    //アイテム化に必要なもの
    private Text textitem;
    public Text keikoku;
    public float timer = 6.0f;
    public Image Button;
    public Image ButtonPush;

    //うずに入った時に回転
    //private bool keyTurboRot=false;
    //private bool keyJumpRor = false;
    private float i = 10;
   // private float j = 0;
    private Vector3 rotate_my;

    private Rigidbody rB;

    public float jumpForce = 20.0f;
    private float turboForce = 1f;

    private int angCout1;

    private ParticleSystem Wind;
    private ParticleSystem Wind2;
    private ParticleSystem Wind3;

    private ParticleSystem Hokori;

    private AudioSource Mahou;
    private AudioSource Kekoku;

    public AudioClip sound01;
    public AudioClip sound02;

    AudioSource audio;
    public AudioClip sound3;
    public AudioClip se_itemerr;

    float time = 3f;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        audio = GetComponent<AudioSource>();

        Mahou = gameObject.AddComponent<AudioSource>();
        Kekoku = gameObject.AddComponent<AudioSource>();

        keikoku.enabled = false;

        Button.enabled = false;
        ButtonPush.enabled = false;

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
        Hokori = GameObject.Find("Dust").GetComponent<ParticleSystem>();
        Wind.Play();
        Wind2.Stop();
        Wind3.Stop();
        Item = 3;                   //アイテム化に必要なもの
        textitem = GameObject.Find("Itemsu").GetComponent<Text>();
        Button = GameObject.Find("ItemButton").GetComponent<Image>();
        ButtonPush = GameObject.Find("ItemButtonPush").GetComponent<Image>();
        SetItemText(Item);
        StartCoroutine("Sleep");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2) && Cursor.lockState == CursorLockMode.Locked)
        {
            OnClick();  //クリックされた時の処理
        }
        GameObject ItemObj = GameObject.Find("Jamp");
        SetItemText(Item);
        if (Input.GetButtonUp("Action") && isSETHI)
        {
            //Debug.Log("押した");
            if (Item > 0)
            {
                Itemsei();
                --Item;
               // Debug.Log("数が減った");

            }
            else
            {
                Item = 0;
                audio.PlayOneShot(se_itemerr);
            }

            //自身の傾き取得
            rotate_my = gameObject.transform.localEulerAngles;
        }
    }

    void OnClick()
    {
        //UnityEditor.EditorApplication.isPlaying = false;

        //if (Cursor.lockState == CursorLockMode.Locked)
        //{
        //    return;  //lockStateがLockedじゃなかったら以後の処理をしない
        //}
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
                    AddRot.eulerAngles = new Vector3(0.01f, 0.3f, 0);
                    GetComponent<Rigidbody>().rotation *= AddRot;
                }
                else if (ang < 0)
                {
                    //yaw = -1;
                    AddRot.eulerAngles = new Vector3(0.01f, -0.3f, 0);
                    GetComponent<Rigidbody>().rotation *= AddRot;
                }
            }

            //下方向に向く　gen=0は押されていない　gen=1は上　gen=-1は↓
            if (gen == -1)
            {

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

                if (transform.localEulerAngles.x <= 359 && transform.localEulerAngles.x >= 340)
                {
                    AddRot.eulerAngles = new Vector3(0.5f, 0, 0);
                    GetComponent<Rigidbody>().rotation *= AddRot;
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

                if (transform.localEulerAngles.x <= 359 && transform.localEulerAngles.x >= 340)
                {
                    angCout1 = 0;
                }
                else
                {
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
            if (transform.localEulerAngles.x <= 15)
            {
                AddRot.eulerAngles = new Vector3(-pitch, yaw, -roll);
                GetComponent<Rigidbody>().rotation *= AddRot;
            }
            else if (transform.localEulerAngles.x >= 350)
            {
                AddRot.eulerAngles = new Vector3(-pitch, yaw, -roll);
                GetComponent<Rigidbody>().rotation *= AddRot;
            }
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
                    input[2] = 0f;
                }

            }
            else if (rot < 0)
            {
                //↓右折
                if (CanMoveRight && Input.GetKey(KeyCode.K))
                {
                    input[3] = 0.8f;
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

        //ターボ中回転させる
        //if (keyTurboRot == true)
        //{
        //    StartCoroutine("RotateTurbo");
        //    keyTurboRot = false;
        //}
        //if(keyJumpRor == true)
        //{
        //    StartCoroutine("RotateJump");
        //    keyJumpRor = false;
        //}

       // Debug.Log(keyTurboRot);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Buns")
        {
            transform.Rotate(new Vector3(0, 180, 0));
            //StartCoroutine("WaitKeyInput");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Jump")
        {
            StartCoroutine("WaitKeyInput1");
            Button.enabled = true;
        }
        if (other.gameObject.tag == "Turbo")
        {
           // keyTurboRot = true;
            StartCoroutine("WaitKeyInput2");

        }

        if(other.gameObject.tag == "kekoku")
        {
            keikoku.enabled = true;
            Kekoku.PlayOneShot(sound02);
        }

        if(other.gameObject.tag == "NossingText")
        {
            keikoku.enabled = false;
            Kekoku.Stop();
        }

        if (other.gameObject.tag == "Over")
        {
            keikoku.enabled = false;
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
            Item = 0;
        }

        if(other.gameObject.tag == "Goal")
        {

            Quaternion mi = transform.localRotation;
            transform.Rotate(new Vector3(0, mi.y, mi.z));
            GetComponent<GoalEffect>().enabled = true;
            GetComponent<ChangeCamera>().enabled = true;
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
            Item = 0;
            GameObject tatu = GameObject.Find("HiWind (Clone)");
            Destroy(tatu);
        }

        if (other.gameObject.tag == "Ring")
        {
            audio.PlayOneShot(sound3);
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
        turboForce += 4f;
        StartCoroutine("RotateTurbo");
        yield return new WaitForSeconds(0.5f);
        turboForce -= 4f;
        Wind2.Stop();
        Wind.Play();
    }

    IEnumerator RotateTurbo()
    {
        for (i = 0; i < 360; i =i+10)
        {
            transform.rotation = Quaternion.Euler(rotate_my.x, rotate_my.y, rotate_my.z + i);
            yield return new WaitForSeconds(0.001f);
        }
    }

    //private void OnTriggerStay(Collider other)
    //{//ゴールに接触している間徐々にスピードを下げる
    //    //上の奴をゴールについたらピタッと止まるように変更
    //    if (other.gameObject.tag == "Goal")
    //    {
            
    //        GetComponent<GoalEffect>().enabled = true;
    //        //Hokori.Play();
    //        if (MovementSpeed >= 0)
    //        {
    //            MovementSpeed = 0;//プレイヤーのスピードを0にする
    //            MovementSpeed -= 5f;// プレイヤーのsぷーどを徐々に下げる
    //            GetComponent<ChangeCamera>().enabled = true;
    //            Item = 0;
    //            GameObject tatu = GameObject.Find("HiWind(Clone)");
    //            Destroy(tatu);
    //            if (MovementSpeed <= 200)
    //            {
    //                Hokori.Stop();
    //            }
    //            //GetComponent<PlayerMove>().enabled = false;
    //            //Debug.Log(MovementSpeed);
    //        }
    //        Wind.Stop();
    //    }
    //}
    void Itemsei()
    {
        time = 3f;
        Vector3 position = transform.position +
              transform.up * offset.y +
              transform.right * offset.x +
              transform.forward * offset.z * 5;

        //回転調整
        Quaternion myTrans = this.transform.localRotation;

        Vector3 yes = this.transform.localEulerAngles;
        yes.y = 180.0f;
        yes.z = 90.0f;
        myTrans.eulerAngles = yes;

        // 生成しています。回転はいじってません。
        Instantiate(ItemPrefab, position, myTrans);
        //Debug.Log("動いた");
        StartCoroutine("Sleep");

        if(Instantiate(ItemPrefab, position, myTrans))
        {
            Mahou.PlayOneShot(sound01);
            Button.enabled = false;
            ButtonPush.enabled = true;
            time--;
            if (time < 0)
            {
                ButtonPush.enabled = false;
                Button.enabled = true;
                time = 3;
            }
        }


    }
    void SetItemText(int Item)
    {
        textitem.text = "アイテム:" + Item.ToString();
    }
    IEnumerator Sleep()
    {
        //Debug.Log("開始");
        isSETHI = false;
        yield return new WaitForSeconds(5);
        //Debug.Log("終わり");
        isSETHI = true;
        GameObject tatu = GameObject.Find("HiWind (Clone)");
        Destroy(tatu, timer);
    }

    public float GetSpeed()
    {
        return MovementSpeed;
    }
}
