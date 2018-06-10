using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : Bullet {

    PoolObject destroyParticle;
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
        if (hitInfo.collider.tag == "BulletHoming")
        {
            //Debug.LogError("Hit ICE");
            hitInfo.collider.gameObject.GetComponent<BulletHoming>().GetDamage(Damage);
        }
        PoolManager.Instance.PushObject(this.gameObject);
        //GameObject.Destroy(this.gameObject);
    }

    protected override void Reset()
    {
        base.Reset();
        Debug.Log("BulletBase Reset");
    }

}
