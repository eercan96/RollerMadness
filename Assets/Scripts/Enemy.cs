using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float speed = 3;
    [SerializeField] private float stopDistance = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        //print(GameObject.FindWithTag("Player").gameObject.name);
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        // target=GameObject.Find("Player").transform; //Kendi yazdýðým Burada tag le deðil nesne ile buldum.
    }

    // Update is called once per frame
    void Update()
    {
        if (target!=null)
        {
            transform.LookAt(target);
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance > stopDistance)
            {
                transform.position += transform.forward * speed * Time.deltaTime;
            } 
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            Destroy(collision.gameObject);
            TimeManager timeManager = FindObjectOfType<TimeManager>();
            timeManager.gameOver = true;
        }
    }
    
    //void FollowingDistance()
    //{
    //    float distance = Vector3.Distance(transform.position, target.position);
    //    if (distance >= stopDistance)
    //    {
    //        transform.position += transform.forward * speed * Time.deltaTime;
    //    }
    //    else if (distance < stopDistance)
    //    {
    //        transform.position += Vector3.zero;
    //    }

    //}


}
