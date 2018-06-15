using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestActor : FriendActor {

    public Priest havePriest;

    Transform thisTransform;    

    private void Awake()
    {
        base.Awake();
        thisTransform = GetComponent<Transform>();
        havePriest = GetComponent<Priest>();
    }
    private void Start()
    {
        base.Start();
    }

    private void Update()
    {
        base.Update();
    }
    
    public Vector3 Pos
    {
        get{
            return thisTransform.localPosition;
        }
        set{
            thisTransform.localPosition = value;
        }
    }
}
