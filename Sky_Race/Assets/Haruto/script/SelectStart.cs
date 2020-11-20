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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
        Screen.lockCursor = false;

        Retry = GameObject.Find("Canvas/Retry").GetComponent<Selectable>();
        Title = GameObject.Find("Canvas/Title").GetComponent<Selectable>();
        Retry.Select();
    }
}
