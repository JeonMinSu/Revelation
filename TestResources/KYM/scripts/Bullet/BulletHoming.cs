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
    [SerializeField]
    private float maxHP;

    private float currentHP;

    private Vector3 targetPosition;   //유도 타겟

    public override void Init()
    {
        moveDir = this.transform.forward;
        currentHP = maxHP;
    }

    private void Update()
    {
        if (target == TargetName.TargetPlayer)
            targetPosition = UtilityManager.Instance.PlayerPosition();
        else if (target == TargetName.TargetDragon)
            targetPosition = UtilityManager.Instance.DragonPosition();
        else
            targetPosition = Vector3.zero;

        if (currentHP <= 0.0f)
            DestoryObject();


    }

    protected override void Move()
    {
        Vector3 _targetDir = (targetPosition - this.transform.position).normalized;
        moveDir = Vector3.Lerp(moveDir, _targetDir, homingPower * Time.fixedDeltaTime);
        transform.position += moveDir * Time.fixedDeltaTime * moveSpeed;
        transform.rotation = Quaternion.LookRotation(moveDir, Vector3.up);
    }

    protected override void OnCollisionEvent()
    {
        if(hitInfo.collider.tag == "PlayerBullet")
        {
            GetDamage(hitInfo.collider.gameObject.GetComponent<BulletBase>().Damage);
            hitInfo.collider.gameObject.GetComponent<BulletBase>().DestoryObject();
            return;
        }
        PoolManager.Instance.PushObject(this.gameObject);
        //얼음기둥 생성
    }

    protected override void Reset()
    {
        base.Reset();
        Debug.Log("homing Bullet Reset");
    }

    public void GetDamage(float damage) { currentHP -= damage; }


}
