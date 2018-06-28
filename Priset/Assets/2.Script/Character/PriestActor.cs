using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sang;
public class PriestActor : FriendActor {

    public Priest havePriest;
    Transform thisTransform;

    public void Init()
    {
        havePriest.init();
    }
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

    protected void Update()
    {
        if (GameManager.instance.NowScene == SceneNum.Home)
            HomeAct();
        else if (GameManager.instance.NowScene == SceneNum.War)
            WarAct();
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

    public void AcitveSkill(int index)
    {

    }
    public void PriestWarSceneStart()
    {
        this.transform.localPosition = new Vector3(0, 0, 0);
        this.transform.localRotation = Quaternion.Euler(90f, 0, 0);
        navMesh.enabled = true;
    }
    protected override void WarAct()
    {
        if (JoyStick.MoveDir.x < 0)
            Left();
        else if (JoyStick.MoveDir.x > 0)
            right();
        if (JoyStick.MoveDir != Vector3.zero)
            MoveAni();
        else
            IdleAni();

        navMeshObject.position += (JoyStick.MoveDir * havePriest.MoveSpeed) * Time.deltaTime;
    }

     
}
