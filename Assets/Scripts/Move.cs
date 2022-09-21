using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Vector3 moment;
    [SerializeField] private float speed = 15f;
    private Rigidbody rigidbody;
    private TimeManager timeManager;
    //[SerializeField] private float x=0;
    //[SerializeField] private float z=0;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        timeManager = FindObjectOfType<TimeManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (timeManager.gameOver == false && timeManager.gamefinished == false)
        {
            MoveThePlayer();
        }
        if (timeManager.gameOver||timeManager.gamefinished)
        {
            rigidbody.isKinematic = true;//oyuncu durur
        }
    }

    private void MoveThePlayer()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        moment = new Vector3(x, 0f, z);
        rigidbody.AddForce(moment);
        //transform.position += moment;

    }


}
