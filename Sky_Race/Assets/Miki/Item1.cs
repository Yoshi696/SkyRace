using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item1 : MonoBehaviour
{

    public int Item;
    public GameObject ItemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Item = 3;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 3; i < 0; i--)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
               
                Debug.Log("投げた");
            }
            else
            {
                //transform.position = new Vector3(0f, transform.position.y - 0.1f, 0f);
            }
          
        }
    }
}
