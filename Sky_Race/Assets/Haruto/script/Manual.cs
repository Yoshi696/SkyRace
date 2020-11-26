using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manual : MonoBehaviour
{
    public Text ManualText;
    public Image backScreen;
    public Image Bbutton;

    void Start()
    {
        ManualText.enabled = true;
        backScreen.enabled = true;
        Bbutton.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "move")
        {
            Bbutton.enabled = false;
            ManualText.enabled = false;
        }

        if (other.gameObject.tag == "Take of")
        {
            backScreen.enabled = false;
        }
    }
}
