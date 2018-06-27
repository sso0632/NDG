using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    Vector3 movepos;
    float speed=0.1f;

    // Update is called once per frame
    void Update () {
        movepos = new Vector3(Time.time* speed, Time.time * speed, 0);
        Matrix4x4 m = Matrix4x4.TRS(movepos,Quaternion.identity, Vector3.one);
        GetComponent<Renderer>().material.SetMatrix("_TextureMatarial", m);
    }
}
