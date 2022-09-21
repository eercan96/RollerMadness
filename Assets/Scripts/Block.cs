using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    // Start is called before the first frame update
    private bool isCollided = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isCollided == false)
        {
            print(collision.gameObject.name);
            GetComponent<MeshRenderer>().material.color = Color.black;
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.score--;
            isCollided = true;

        }
        //collision deðiþkeni þuandaki bulunðumuz nesneye çarpan objeyi tutar. 1 kere çalýþýr.Bu sayede objenin propertylerine ulaþabiliriz.
        

    }
}
