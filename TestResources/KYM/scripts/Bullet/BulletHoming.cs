using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHoming : Bullet
{
    enum TargetName
    {
        TargetNull,
        TargetPlayer,
        TargetDragon
    }

    [SerializeField]
    private float homingPower;  //유도력
    [SerializeField]
    private TargetName target;

    private Vector3 targetPosition;   //유도 타겟

    private void Update()
    {
        if (target == TargetName.TargetPlayer)
            targetPosition = UtilityManager.Instance.PlayerPosition();
        else if (target == TargetName.TargetDragon)
            targetPosition = UtilityManager.Instance.DragonPosition();
        else
            targetPosition = Vector3.zero;
    }

    protected override void Move()
    {
        Vector3 _targetDir = (targetPosition - this.transform.position).normalized;
        moveDir = Vector3.Lerp(moveDir, _targetDir, homingPower * Time.fixedDeltaTime);
        transform.position += moveDir * Time.fixedDeltaTime * moveSpeed;
    }

    protected override void OnCollisionEvent()
    {
        PoolManager.Instance.PushObject(this.gameObject);
        //얼음기둥 생성
    }

    protected override void Reset()
    {
        base.Reset();
        Debug.Log("homing Bullet Reset");
    }

}
