using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private GameObject mainCamera;
    private GameObject subCamera;

    public Text OverText;

    private ParticleSystem Wind;

    void Start()
    {
        mainCamera = GameObject.Find("Camera");
        subCamera = GameObject.Find("SubCamera");
        OverText.enabled = false;

        Wind = GameObject.Find("wind").GetComponent<ParticleSystem>();

        subCamera.SetActive(false);
        mainCamera.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Over")
        {
            GetComponent<Rotation>().enabled = true;
            Wind.Stop();
            mainCamera.SetActive(false);
            subCamera.SetActive(true);
            OverText.enabled = true;
            Invoke("LoadScene", 2f);
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene("GameResult");
    }
}
