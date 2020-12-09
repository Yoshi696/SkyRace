using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    private Text GoalScore;
    private Text distanceScore;
    private Text TotalScore;
    private Text TotalCalculation;
    public int GoalPoint;
    public double Distance;
    public double Total;
    public int Goal;


    void Start()
    {
        GoalScore = GameObject.Find("goalpoint").GetComponent<Text>();
        distanceScore = GameObject.Find("kyori").GetComponent<Text>();
        TotalScore = GameObject.Find("totalscore").GetComponent<Text>(); 
        TotalCalculation = GameObject.Find("total").GetComponent<Text>();
        //トータルスコアの計算　今は距離を整数にしてから計算している

        if (Goal != 0)
        {
            //Debug.Log("ゴールシチャッタ");
            Total = (int)GoalPoint + ((int)Distance * 10);
        }
        else
        {
            Debug.Log("オチチャッタ");
            Total = (((int)Distance * 10)/2);//Goalしていないので点数を半分にする
        }
        SetScoreText(GoalPoint);

    }

    private void SetScoreText(int Score)
    {
        GoalScore.text = "ゴールポイント:" + Score.ToString();
        distanceScore.text = "飛行距離:" + Distance.ToString("0.00m");
        //トータルスコアの表示　今は整数に直したものを表示する
        TotalScore.text = "トータルスコア:" + Total.ToString("0");

        TotalCalculation.text = "    ";
        //if (Goal != 0)
        //{
        //    TotalCalculation.text = "TotalScore = GoalPoint+((Distance * 100)/10)";
        //}
        //else
        //{
        //    TotalCalculation.text = "TotalScore = (((Distance * 100)/10)/2)";
        //}
    }

    public void AddScore(int point)
    {
        GoalPoint += point;
        SetScoreText(GoalPoint);
    }

}
