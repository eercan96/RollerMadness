using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offsetVector;
    [SerializeField] private float cameraFollowSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        offsetVector = CalculateOffset(target);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target!=null)
        {
            MoveTheCamera(); 
        }
    }
    private void MoveTheCamera()
    {
        Vector3 targetToMove = target.position + offsetVector;
        transform.position = Vector3.Lerp(transform.position, targetToMove, cameraFollowSpeed * Time.deltaTime);
        transform.LookAt(target.transform.position);
    }
    private Vector3 CalculateOffset(Transform newTraget)
    {

        return transform.position - newTraget.position;
    }
}
