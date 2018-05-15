using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    protected float moveSpeed;           //이동 속도
    [SerializeField]
    protected float damage;                //데미지
    [SerializeField]
    protected float colliderRadius;        //충돌 반경

    protected Vector3 moveDir;           //이동 방향
    protected Vector3 prevPosition;      //이전 위치
    protected RaycastHit colInfo;          //충돌 정보              

    //초기화
    private void Start()
    {
        Init();
        prevPosition = this.transform.position;
    }

    public virtual void Init() { }
    //초기화
    public  virtual void Init(Vector3 _moveDir){ moveDir = _moveDir; }

    //이동
    protected virtual void Move(){ }

    //충돌 체크
    protected virtual bool CollisionCheck()
    {
        Vector3 _dir = transform.position - prevPosition;

        Ray _ray = new Ray(this.transform.position, _dir.normalized);
        return Physics.SphereCast(_ray, colliderRadius, out colInfo, _dir.magnitude);
    }

    //충돌시 이벤트
    protected virtual void OnCollisionEvent() {  }

	// Update is called once per frame
	void FixedUpdate ()
    {
        prevPosition = this.transform.position;
        Move();
        bool _isCollision = CollisionCheck();
        if (_isCollision) OnCollisionEvent();
	}
}
