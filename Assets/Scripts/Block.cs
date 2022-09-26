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
        if (isCollided == false && collision.gameObject.tag =="Player")
        {
            print(collision.gameObject.name);
            GetComponent<MeshRenderer>().material.color = Color.black;
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.score--;
            isCollided = true;

        }
        //collision de�i�keni �uandaki bulun�umuz nesneye �arpan objeyi tutar. 1 kere �al���r.Bu sayede objenin propertylerine ula�abiliriz.
        

    }
}
