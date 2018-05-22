using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : Bullet {

    // Use this for initialization
    public override void Init()
    {
        moveDir = this.transform.forward;
    }

    protected override void Move()
    {
        this.transform.position += moveDir * Time.fixedDeltaTime * moveSpeed;
    }

    protected override void OnCollisionEvent()
    {
        PoolManager.Instance.PushObject(this.gameObject);
        //GameObject.Destroy(this.gameObject);
    }

    protected override void Reset()
    {
        base.Reset();
        Debug.Log("BulletBase Reset");
    }

}
