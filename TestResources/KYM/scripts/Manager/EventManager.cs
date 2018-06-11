using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{

    public void EventBulletExplosion(PoolObject poolObj, Vector3 pos)
    {
        GameObject obj;
        PoolManager.Instance.PopObject(poolObj.pooltag, out obj);
        if(obj != null)
        {
            obj.transform.position = pos;
        }
    }

    //void EventIceBlockMake(Vector3 pos)
    //{

    //}

}
