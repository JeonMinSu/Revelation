using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class PlayerPawn : MonoBehaviour {

    //이동
    private float turnSpeed = 360.0f;
    private float accelSpeed = 100.0f;
    private float breakSpeed = 100.0f;
    private float maxSpeed = 15.0f;

    //대쉬
    private float flashDistance = 10.0f;
    private float flashTime = 0.1f;
    private float flashDelay = 3.0f;

    //점프
    private float jumpPower = 20.0f;

 
    Rigidbody rigid;
    CapsuleCollider col;
    private bool isAir;
  
	// Use this for initialization
	void Start ()
    {
        rigid = this.GetComponent<Rigidbody>();
        col = this.GetComponent<CapsuleCollider>();
        isAir = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void AirCheck()
    {
        Ray _ray = new Ray(transform.position, Vector3.down);
        isAir = !Physics.SphereCast(_ray, col.radius, col.height / 2 + 0.01f);
        Debug.Log(isAir);
    }

    void Move()
    {
        Vector3 _addDir = Vector3.zero;
        Vector3 _velocity = rigid.velocity;
        //이동 구문
        if (PlayerController.MoveLeft())
        {
            _addDir = -transform.right * accelSpeed * Time.fixedDeltaTime;
        }
        if (PlayerController.MoveRight())
        {
            _addDir = transform.right * accelSpeed * Time.fixedDeltaTime;
        }
        if (PlayerController.MoveForward())
        {
            _addDir = transform.forward * accelSpeed * Time.fixedDeltaTime;
        }
        if (PlayerController.MoveBackward())
        {
            _addDir = -transform.forward * accelSpeed * Time.fixedDeltaTime;
        }

        //이동값 없고 & 공중 아니고 & 가속도가 있음
        if (_addDir == Vector3.zero && !isAir && _velocity.magnitude > breakSpeed * Time.fixedDeltaTime)
        {
            _addDir = -_velocity.normalized * breakSpeed * Time.fixedDeltaTime;

        }

        //가속도 적용  
        _velocity += _addDir;
        if (_velocity.magnitude > maxSpeed && !isAir)
        {
            _velocity = _velocity.normalized * maxSpeed;
        }
        rigid.velocity = _velocity;
    }

    private void FixedUpdate()
    {
        AirCheck();
        Move();
    }
}
