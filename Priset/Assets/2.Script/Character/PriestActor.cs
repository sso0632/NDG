using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestActor : FriendActor {

    Priest havePriest;

    private void Awake()
    {
        base.Awake();
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
}
