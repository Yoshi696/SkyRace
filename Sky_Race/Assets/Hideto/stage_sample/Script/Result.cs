using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{

    //Point取得用の変数を用意
    private int High = 50;
    private int Medium = 20;
    private int Low = 10;
    private int score;

    private void OnTriggerEnter(Collider other)    //ゴールに接触した瞬間に入る
    {
        if (other.gameObject.tag == "High_P")
        {
            Debug.Log("高得点");
            score = High;
                
        }
        else if(other.gameObject.tag == "Medium_P")
        {
            Debug.Log("中得点");
            score = Medium;

        }
        else if (other.gameObject.tag == "Low_P")
        {
            Debug.Log("低得点");
            score = Low;

        }
        Debug.Log(score);
    }

}
