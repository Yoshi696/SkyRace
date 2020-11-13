using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Result : MonoBehaviour
{
    //距離を表示しないならここから
    [SerializeField]
    private Transform targetObj;
    [SerializeField]
    private Text PPUI;
    [SerializeField]
    private Text SPUI;
    [SerializeField]
    private Text DSUI;
    //ここまではコメントアウトする

    private float colliderOffset;

    //Point取得用の変数を用意
    private int High = 50;
    private int Medium = 20;
    private int Low = 10;
    private float pm = 100;
    private int GoalPoint;
    private double distance;

    //デバック用の変数
    private bool Log = true;//デバック表示true 非表示false

    //Goalの文字テキスト
    public Text GoalText;

    void Strat()
    {
        colliderOffset = GetComponent<CharacterController>().radius + targetObj.GetComponent<CharacterController>().radius;
        GoalText.enabled = false;
    }
    void Update()
    {
        //スタート座標とプレイヤー座標の取得
        Vector3 v = transform.position;//プレイヤーの座標
        Vector3 v2 = targetObj.position;//スタート座標
        distance = (v.z - v2.z) - colliderOffset;//距離計算

        if (PPUI != null)
        {
            //プレイヤーのz座標を表示
            PPUI.text = v.z.ToString("0.00m");
            //スタートのz座標を表示
            SPUI.text = v2.z.ToString("0.00m");
            //プレイヤーとスタートのz軸の距離を表示(スコアに使うのはこっちかな)
            DSUI.text = distance.ToString("0.00m");

        }
        else if(Log == true)
        {//上の条件に当てはまらない時のデバック表示
            Debug.Log(v.z.ToString("0.00m"));
            Debug.Log(v2.z.ToString("0.00m"));
            Debug.Log(distance.ToString("0.00m"));
        }

    }

    public void onClick()
    {

        // シーン切り替え
//        SceneManager.LoadScene("GameResult");
    }
    private void GameResultLoaded(Scene next, LoadSceneMode mode)
    {
        // シーン切り替え後のスクリプトを取得
        var gameManager = GameObject.FindWithTag("ResultScore").GetComponent<ResultScore>();

        // データを渡す処理
        gameManager.GoalPoint = GoalPoint;
        gameManager.Distance = distance;

        // イベントから削除
        SceneManager.sceneLoaded -= GameResultLoaded;
    }

    private void OnTriggerEnter(Collider other)    //ゴールに接触した瞬間に入る
    {
        if (other.gameObject.tag == "High_P")
        {
            Debug.Log("高得点");
            GoalPoint = High;
                
        }
        else if(other.gameObject.tag == "Medium_P")
        {
            Debug.Log("中得点");
            GoalPoint = Medium;

        }
        else if (other.gameObject.tag == "Low_P")
        {
            Debug.Log("低得点");
            GoalPoint = Low;

        }
        Debug.Log(GoalPoint);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "High_P")
        {
            Debug.Log("出たから中得点");
            GoalPoint = Medium;

        }
        else if (other.gameObject.tag == "Medium_P")
        {
            Debug.Log("出たから低得点");
            GoalPoint = Low;

        }
    }
    private void OnCollisionStay(Collision other)
    {//ゴールに接触している間徐々にスピードを下げる
        if (other.gameObject.tag == "Goal")
        {
            if (pm >= 0)
            {
                pm -= 0.5f;
                Debug.Log(pm);
            }
            else if(pm <= 0)
            {
                GoalText.enabled = true;
                //              GameObject gm = GameObject.Find("ResultScore");
                //            gm.GetComponent<ResultScore>().AddScore(GoalPoint);

                // イベントに登録
                SceneManager.sceneLoaded += GameResultLoaded; 
                Invoke("LoadScene", 1f);
            }
        }
    }
    void LoadScene()
    {
        //Result画面を読み込む
        SceneManager.LoadScene("GameResult");
    }
}
