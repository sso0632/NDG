
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    Transform followTarget;
    Vector3 followVector;


    private void Start()
    {
        followTarget = GameObject.FindGameObjectWithTag("priest").transform;
        Debug.Log(followTarget);
    }

    private void LateUpdate()
    {
        if (followTarget == null)
            return;

        followVector = followTarget.position;
        followVector.y = 10;

        transform.position = Vector3.Lerp(transform.position, followVector, Time.deltaTime);
    }
}
