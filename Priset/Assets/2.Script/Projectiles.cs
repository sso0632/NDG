using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sang;

public class Projectiles : MonoBehaviour {

    int AttackPoint;            //방향
    float MoveSpeed;            //날라가는 속도  
    Vector3 Direction;          //날라가는 방향 
    DeadorLive Die;             //사라짐 체크  
    public Animator haveAnimator;      //애니메이터가 있을경우
    public ParticleSystem haveParticle;    //파티클이 있을 경우
    string TargetTag;                //발사체 주인의 태그

    public SpriteRenderer spritegone;       //스프라이트가 없어져야 할때 
    private void Update()
    {
        if(Die== DeadorLive.LIVE)
            Move();
    }

    void Init()
    {
        Die = DeadorLive.LIVE;
        StartCoroutine("LifeTime");
    }

    public void CreateClone(Vector3 StartPos, int _AttackPoint, float _MoveSpeed, Vector3 targetPos, string _TargetTag)
    {
        Projectiles Clone=Instantiate(this.gameObject).GetComponent<Projectiles>();
        Clone.TargetTag = _TargetTag;
        Clone.transform.position = StartPos;
        Clone.AttackPoint = _AttackPoint;
        Clone.MoveSpeed = _MoveSpeed;
        Clone.DirectionSet(targetPos);
        Clone.Init();
    }

    void SetAngle(Vector3 targetPos)
    {
        float angle= Mathf.Atan2(targetPos.z, targetPos.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(90, 0, angle);
    }

void DirectionSet(Vector3 targetPos)
    {
        Direction = (targetPos-transform.position).normalized;
        Direction.y = 0f;
        SetAngle(Direction);
    }

    void Move()
    {
        transform.position+=(Direction * MoveSpeed * Time.deltaTime);
    }

    void Hit()
    {
        if (haveAnimator != null)
        {
            haveAnimator.SetBool("hit", true);
        }
        else if (haveParticle != null)
        {
            spritegone.enabled = false;
            haveParticle.Play();

        }
        Die = DeadorLive.DEAD;
        StartCoroutine("DieTime");

    }
    IEnumerator DieTime()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TargetTag))
        {
           other.GetComponent<Acter>().Hit(AttackPoint);
           Hit();
        }
    }

    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
