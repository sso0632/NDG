
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform followTarget;
    Vector3 followVector;
    private void Start()
    {
        followTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }
    //private void Update()
    //{
        
    //}
    private void LateUpdate()
    {
        followVector = followTarget.position;
        followVector.z = -10;


        //transform.position = followVector;

        transform.position = Vector3.Lerp(transform.position, followVector, Time.deltaTime);

    }
}
