using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manual1 : MonoBehaviour
{
    public Image buttonPush;
    public Text pushText;

    void Start()
    {
        buttonPush.enabled = false;
        pushText.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "move")
        {
            buttonPush.enabled = true;
            pushText.enabled = true;
        }

        if(other.gameObject.tag == "Take of")
        {
            buttonPush.enabled = false;
            pushText.enabled = false;
        }
    }
}
