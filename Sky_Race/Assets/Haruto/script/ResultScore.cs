using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    private Text GoalScore;
    private Text distanceScore;
    private Text TotalScore;
    public int GoalPoint;
    public double Distance;
    public double Total;


    void Start()
    {
        GoalScore = GameObject.Find("goalpoint").GetComponent<Text>();
        distanceScore = GameObject.Find("kyori").GetComponent<Text>();
        TotalScore = GameObject.Find("totalscore").GetComponent<Text>();
        //トータルスコアの計算　今は距離を整数にしてから計算している

        if (GoalPoint > 0)
        {
            Debug.Log("ゴールシチャッタ");
            Total = (double)GoalPoint + ((Distance * 100)/10);
        }
        else
        {
            Debug.Log("オチチャッタ");
            Total = (((Distance * 100)/10)/2);//Goalしていないので点数を半分にする
        }
        SetScoreText(GoalPoint);

    }

    private void SetScoreText(int Score)
    {
        GoalScore.text = "GoalPoint:" + Score.ToString();
        distanceScore.text = "Distance:" + Distance.ToString("0.00m");
        //トータルスコアの表示　今は整数に直したものを表示する
        TotalScore.text = "TotalScore:" + Total.ToString("0");

    }

    public void AddScore(int point)
    {
        GoalPoint += point;
        SetScoreText(GoalPoint);
    }

}
