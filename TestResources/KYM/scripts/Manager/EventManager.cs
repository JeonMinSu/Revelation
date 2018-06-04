using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    [SerializeField] private PoolObject bulletExplosionParticle;
    //[SerializeField] private PoolObject IceBlock;
    public void EventBulletExplosion(Vector3 pos)
    {
        GameObject obj;
        PoolManager.Instance.PopObject(bulletExplosionParticle.pooltag, out obj);
        if(obj != null)
        {
            obj.transform.position = pos;
        }
    }

    //void EventIceBlockMake(Vector3 pos)
    //{

    //}

}
