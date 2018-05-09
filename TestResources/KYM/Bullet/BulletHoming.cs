using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHoming : Bullet
{
    [SerializeField]
    private float homingPower;  //유도력
    private Transform target;   //유도 타겟
    protected override void Move()
    {
        Vector3 _targetDir = (target.position - this.transform.position).normalized;
        moveDir = Vector3.Slerp(moveDir, _targetDir, homingPower * Time.fixedDeltaTime);
    }

    protected override void OnCollisionEvent()
    {

        //얼음기둥 생성
    }
}
