using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObject : PoolObject
{

    private void Awake()
    {

    }

    public void EffectOff()
    {
        PoolManager.Instance.PushObject(this.gameObject);
    }

    public virtual void DestoryObject()
    {
        PoolManager.Instance.PushObject(this.gameObject);
    }
	
}
