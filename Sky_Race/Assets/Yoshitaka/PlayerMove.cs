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

	public float MovementSpeed = 100f;
	public float RotationSpeed = 100f;
	public int karbspeed = 2;

	private bool canTranslate;
	private bool canRotate;

	private Rigidbody rB;

	public float jumpForce = 20.0f;

	void Start()
	{
		canTranslate = CanRotateYaw || CanRotatePitch || CanRotateRoll;
		canRotate = CanMoveForward || CanMoveBack || CanMoveRight || CanMoveLeft || CanMoveUp || CanMoveDown;
		rB = GetComponent<Rigidbody>();

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
        float gen = Input.GetAxisRaw("Pitch");
        float rot = Input.GetAxisRaw("Horizontal");

        //回転

        if (canRotate)
        {
            Quaternion AddRot = Quaternion.identity;
            float yaw = 0;
            float pitch = 0;
            float roll = 0;
            float key = 0;
            Debug.Log(yaw);

            //左右方向に回転・これを連動すればカーブいける！
			if (CanRotateYaw)
            {
                yaw = Input.GetAxis("Yaw")/*これで回転しているからキーを変えてみる*/ * (Time.fixedDeltaTime * RotationSpeed);
            }
            //自分が上下に傾く（不必要かも）
            //if (gen < 0)
            //{
            //    //transform.Rotate(45, 0, 0);
            //    //if (CanRotatePitch)
            //    //{
            //    pitch = Input.GetAxis("Pitch") * (Time.fixedDeltaTime * RotationSpeed);
            //}
            //else
            //{
            //    //if (CanRotatePitch)
            //    //{
            //    //	pitch = Input.GetAxis("Pitch") * (Time.fixedDeltaTime * RotationSpeed);
            //    //}
            //}

            //自分が横に傾く（傾くと変な動きするから傾きは別作った方がいいかも？）
            if (CanRotateRoll)
            {
                roll = Input.GetAxis("Roll") * (Time.fixedDeltaTime * RotationSpeed);
            }

            //実際傾く所
            AddRot.eulerAngles = new Vector3(-pitch, yaw, -roll);
            Debug.Log(AddRot);
            if (AddRot.y <= 45)
            {
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
					input[2] = 0.5f;
				}

			}
            else if (rot < 0)
            {
				//↓右折
				if (CanMoveRight && Input.GetKey(KeyCode.K))
				{
					input[3] = 1;
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
            else if(gen < 0)
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
			Vector3 AddPos = input[0] * Vector3.forward + input[2] * Vector3.left + input[4] * Vector3.up
				+ input[1] * Vector3.back + input[3] * Vector3.right + input[5] * Vector3.down;
			AddPos = GetComponent<Rigidbody>().rotation * AddPos;

			GetComponent<Rigidbody>().velocity = AddPos * (Time.fixedDeltaTime * curSpeed);
		}
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Buns")
        {
            transform.Rotate(new Vector3(0, 180, 0));
           // StartCoroutine("WaitKeyInput");
        }
	}

	IEnumerator WaitKeyInput()
    {
        this.gameObject.GetComponent<PlayerMove>().enabled = false;
        {
            yield return new WaitForSeconds(1.0f);
        }
        this.gameObject.GetComponent<PlayerMove>().enabled = true;
    }

	private void OnCollisionStay(Collision other)
	{//ゴールに接触している間徐々にスピードを下げる
		if (other.gameObject.tag == "Goal")
		{
			if (MovementSpeed >= 0)
			{
				MovementSpeed -= 5f;
				Debug.Log(MovementSpeed);
			}
		}
	}
}
