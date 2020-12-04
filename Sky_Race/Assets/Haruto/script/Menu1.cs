using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu1 : MonoBehaviour
{
	Button title;

    void Start()
	{
        // ボタンコンポーネントの取得
        title = GameObject.Find("/Canvas/Title").GetComponent<Button>();
		title.Select();
	}

    private void Update()
    {
        //クリックされた時 かつ lockStateがLockedではない時だけ実行
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2) && Cursor.lockState == CursorLockMode.Locked)
        {
            OnClick();  //クリックされた時の処理
        }
    }
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
