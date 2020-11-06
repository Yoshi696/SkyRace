using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    private Text GoalScore;
    private Text distanceScore;
    private Text TotalScore;
    private int GoalPoint;

    void Start()
    {
        GoalScore = GameObject.Find("goalpoint").GetComponent<Text>();
        distanceScore = GameObject.Find("kyori").GetComponent<Text>();
        TotalScore = GameObject.Find("totalscore").GetComponent<Text>();
        GoalPoint = 0;
        SetScoreText(GoalPoint);
    }

        private void SetScoreText(int Score)
        {
            GoalScore.text = "GoalPoint:" + Score.ToString();
        }

    public void AddScore(int point)
    {
        GoalPoint += point;
        SetScoreText(GoalPoint);
    }

}
