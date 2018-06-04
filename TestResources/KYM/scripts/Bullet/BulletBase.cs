﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : Bullet {

    // Use this for initialization
    public override void Init()
    {
        moveDir = this.transform.forward;
        prevPosition = this.transform.position;
    }

    protected override void Move()
    {
        this.transform.position += moveDir * Time.fixedDeltaTime * moveSpeed;
    }

    protected override void OnCollisionEvent()
    {
        for (int i = 0; i < hitInfo.Length; i++)
        {
            Collider _col = hitInfo[i].collider;
            if (col.tag == "BulletHoming")
            {
                col.gameObject.GetComponent<BulletHoming>().GetDamage(Damage);
                break;
            }
        }
        if(hitInfo.Length > 0)
        EventManager.Instance.EventBulletExplosion(hitInfo[0].point);

        PoolManager.Instance.PushObject(this.gameObject);
    }

    protected override void Reset()
    {
        base.Reset();
        Debug.Log("BulletBase Reset");
    }

}
