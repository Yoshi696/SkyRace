using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu2 : MonoBehaviour
{
	Button next;

    void Start()
	{
		// ボタンコンポーネントの取得
		next = GameObject.Find("/Canvas/next").GetComponent<Button>();
		next.Select();
	}
}
