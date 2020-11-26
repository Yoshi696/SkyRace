using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
	Button Stage1;
    Button Stage2;
    Button Stage3;
    Button Stage4;
    Button Stage5;

    void Start()
	{
        //マウスポインタ消すやつ
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //Screen.lockCursor = false;


        // ボタンコンポーネントの取得
        Stage1 = GameObject.Find("/Canvas/Stage1").GetComponent<Button>();
		Stage2 = GameObject.Find("/Canvas/Stage2").GetComponent<Button>();
		Stage3 = GameObject.Find("/Canvas/Stage3").GetComponent<Button>();
        Stage4 = GameObject.Find("/Canvas/Stage4").GetComponent<Button>();
        Stage5 = GameObject.Find("/Canvas/Stage5").GetComponent<Button>();
        Stage1.Select();
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
        //UnityEditor.EditorApplication.isPlaying = false;

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            return;  //lockStateがLockedじゃなかったら以後の処理をしない
        }
    }
}
