using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SubPlayerController : MonoBehaviour {

    public static Transform PlayerTransform;

    private void Awake()
    {
        PlayerTransform = transform;
    }
    private void Update()
    {
        transform.position += JoyStick.MoveDir * Time.deltaTime * 3;
    }


}
