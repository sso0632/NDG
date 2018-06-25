
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    Transform followTarget;
    Vector3 followVector;


    float XLimite=17f;
    float ZLimite=20f;
   
    Vector3 LimitewVector3;

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

        CheckLimite();
        transform.position = Vector3.Lerp(transform.position, followVector, Time.deltaTime);
    }

    void CheckLimite()
    {

        if (followVector.x > XLimite)
        {
            followVector.x = XLimite;
        }
        else if (followVector.x < -XLimite)
        {
            followVector.x = -XLimite;
        }

        if (followVector.z > ZLimite)
        {
            followVector.z = ZLimite;
        }
        else if (followVector.z < -ZLimite)
        {
            followVector.z = -ZLimite;
        }
    }
}
