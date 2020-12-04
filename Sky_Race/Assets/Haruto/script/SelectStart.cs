using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectStart : MonoBehaviour
{
    Selectable Retry;　//リトライボタン
    Selectable Title;   //タイトルボタン

    void Start()
    {
        //マウスポインタ消すやつ
        //Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.Locked;
        //Screen.lockCursor = false;

        Retry = GameObject.Find("Canvas/Retry").GetComponent<Selectable>();
        Title = GameObject.Find("Canvas/Title").GetComponent<Selectable>();
        Retry.Select();
    }

    void Update()
    {
        //クリックされた時 かつ lockStateがLockedではない時だけ実行
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2) && Cursor.lockState == CursorLockMode.Locked)
        {
            OnClick();  //クリックされた時の処理
        }

        //if (Input.GetMouseButtonDown(0) == true || Input.GetMouseButtonDown(1) == true || Input.GetMouseButtonDown(2) == true)
        //{
        //    return;
        //}
    }

    //クリックされた時にOnClickを呼び出すようにしておく
    void OnClick()
    {
        // UnityEditor.EditorApplication.isPlaying = false;

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            //Debug.Log("yes");

            return;  //lockStateがLockedじゃなかったら以後の処理をしない
        }
    }
}
