using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum EFFECTTAGS
//{
//    Howling,
//    Dust,
//    LeftPow,
//    RightPow,
//    LClaw,
//    RClaw
//}


[RequireComponent(typeof(PoolObject))]
public class EffectObject : PoolObject
{
    public void EffectOff()
    {
        PoolManager.Instance.PushObject(this.gameObject);
    }

    public virtual void DestoryObject()
    {
        PoolManager.Instance.PushObject(this.gameObject);
    }
	
}
