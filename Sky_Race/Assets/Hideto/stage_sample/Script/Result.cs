﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Result : MonoBehaviour
{
    //数値の表示用↓
//    [SerializeField]
//    private Transform targetObj = null;
    //[SerializeField]
    //private Text PPUI = null;
    //[SerializeField]
    //private Text SPUI = null;
    [SerializeField]
    private Text SUMUI = null;
    //[SerializeField]
    //private Text PDUI = null;
    //数値の表示用↑

    private float colliderOffset;

    //Point取得用の変数を用意
    private int High = 1000;
    private int Medium = 500;
    private int Low = 250;
 //   private float pm = 100;
    private int GoalPoint;
    private int RingP;
    private double distance;
    private Vector3 v2;
    private double sum = 0.0f;


    private AudioSource atack;


    public AudioClip sound01;
    public AudioClip sound3;


    private ParticleSystem Gon;

    public static bool ringT;

    // ゴールしたかどうか
    private int Goal = 2; //0:GameOver 1:Goal
    //Goalの文字テキスト
    public Text GoalText;

    void Start()
    {
        // colliderOffset = GetComponent<CharacterController>().radius + targetObj.GetComponent<CharacterController>().radius;
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

        Gon = GameObject.Find("Collide").GetComponent<ParticleSystem>();

        ringT = false;

        Gon.Stop();

        GoalText.enabled = false;

        atack = gameObject.AddComponent<AudioSource>();

        GoalPoint = 0;
        RingP = 0;
    }
    private void OnEnable()
    {
        v2 = transform.position; //最初のプレイヤーの位置を保存

    }
    private void FixedUpdate()
    {
        if (Goal == 2 )
        {

            sum += distance;//飛行距離を合計する
            v2 = transform.position;//キーが押されたときの座標取得
        }
    }
    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //スタート座標とプレイヤー座標の取得
        Vector3 v = transform.position;//プレイヤーの座標

        distance = Vector3.Distance(v,v2) - colliderOffset;// 今の距離とその前の距離の計算キーが押されたら更新する

        //  distance = (v.z - v2.z) - colliderOffset;//Z距離計算
       // Debug.Log(sum.ToString("0.00m"));
        //数値の表示

        SUMUI.text = "飛行距離" + sum.ToString("0.00m");
        //if (PPUI != null)
        //{
        //    //プレイヤーのz座標を表示
        //    PPUI.text = "プレイヤー座標"+v.z.ToString("0.00m");
        //    //スタートのz座標を表示
        //    SPUI.text = "スタート座標"+v2.z.ToString("0.00m");
        //    //プレイヤーの飛行距離を表示(スコアに使うのはこっちかな)
        //    SUMUI.text = "飛行距離:"+ sum.ToString("0.00m");

        //    PDUI.text = "座標:" + distance.ToString("0.00m");

        //}

        ////デバック表示
        //    Debug.Log(FastPos.ToString("0.00m"));
        //    Debug.Log(v.z.ToString("0.00m"));
        //    Debug.Log(v2.z.ToString("0.00m"));
        //    Debug.Log(distance.ToString("0.00m"));
        //




    }


    private void OnTriggerEnter(Collider other)    //ゴールに接触した瞬間に入る
    {
        if (other.gameObject.tag == "High_P")
        {
            //Hanabi1.Play();
            //Hanabi2.Play();
            //Hanabi3.Play();
            //            Debug.Log("高得点");
            GoalPoint = High;
                
        }
        else if(other.gameObject.tag == "Medium_P")
        {
            //Hanabi1.Play();
            //Hanabi2.Play();
            //Hanabi3.Play();
            //            Debug.Log("中得点");
            GoalPoint = Medium;

        }
        else if (other.gameObject.tag == "Low_P")
        {
            //Hanabi1.Play();
            //Hanabi2.Play();
            //Hanabi3.Play();
            //            Debug.Log("低得点");
            GoalPoint = Low;

        }
        //Debug.Log(GoalPoint);
        //ゲームオーバーになった時の処理
        if(other.gameObject.tag == "Over")
        {
            //sum += distance;
            //v2 = transform.position;//プレイヤー座標
            Goal = 0;
            // イベントに登録
            SceneManager.sceneLoaded += GameResultLoaded;
            Invoke("LoadScene", 1f);

        }

        if (other.gameObject.tag == "drop down")
        {
            Gon.Play();
            atack.PlayOneShot(sound01);
            GetComponent<PlayerMove>().enabled = false;
            // GetComponent<PM_test>().enabled = false;
            //GetComponent<sampleRotation>().enabled = true;
            GetComponent<Rotation>().enabled = true;
            //GetComponent<sampleRotation>().enabled = true;
            GetComponent<Gravity>().enabled = false;

        }

        if (other.gameObject.tag == "Goal")
        {

            GetComponent<HorizontalRotation>().enabled = true;

            //if (pm >= 0)
            //{
            //pm -= 0.5f;
            //Debug.Log(pm);
            //}
            //else if (pm <= 0)
            //{
            Goal = 1;// ゴールした
            //sum += distance;
            //v2 = transform.position;//プレイヤー座標
            GoalText.enabled = true;
            //              GameObject gm = GameObject.Find("ResultScore");
            //            gm.GetComponent<ResultScore>().AddScore(GoalPoint);

            // イベントに登録
            SceneManager.sceneLoaded += GameResultLoaded;
            Invoke("LoadScene", 4f);
            //}
        }

        if (other.gameObject.tag == "Ring")
        {
            atack.PlayOneShot(sound3);
            RingP += 10;
            ringT = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {//トリガーから出たとき
        if (other.gameObject.tag == "High_P")
        {
            //           Debug.Log("出たから中得点");
            GoalPoint = Medium;

        }
        else if (other.gameObject.tag == "Medium_P")
        {
            //            Debug.Log("出たから低得点");
            GoalPoint = Low;

        }
        else if (other.gameObject.tag == "Low_P")
        {
            //           Debug.Log("点数ナシ");
            GoalPoint = 0;

        }
        if (other.gameObject.tag == "MoveOn")
        {

            //GetComponent<PlayerMove>().enabled = true;
      //      GetComponent<PM_test>().enabled = true;
       //     GetComponent<sampleRotation>().enabled = false;

        }


    }
    void LoadScene()
    {
        //Result画面を読み込む
        SceneManager.LoadScene("GameResult");
    }
    private void GameResultLoaded(Scene next, LoadSceneMode mode)
    {
        // シーン切り替え後のスクリプトを取得
        var gameManager = GameObject.FindWithTag("ResultScore").GetComponent<ResultScore>();

        GoalPoint += RingP;
        // データを渡す処理
        gameManager.GoalPoint = GoalPoint;
        gameManager.Distance = sum;
        gameManager.Goal = Goal;
     //   gameManager.RingP = RingP;


        // イベントから削除
        SceneManager.sceneLoaded -= GameResultLoaded;
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Goal")
        {
            Gon.Play();
            atack.PlayOneShot(sound01);
            GetComponent<PlayerMove>().enabled = false;
           // GetComponent<PM_test>().enabled = false;
            //GetComponent<sampleRotation>().enabled = true;
            GetComponent<Rotation>().enabled = true;
            //GetComponent<sampleRotation>().enabled = true;
            GetComponent<Gravity>().enabled = false;

        }
    }
    
}
