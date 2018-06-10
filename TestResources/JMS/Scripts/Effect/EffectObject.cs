using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EFFECTTAGS
{
    Howling,
    Dust,
    LeftPow,
    RightPow,
    LClaw,
    RClaw
}


[RequireComponent(typeof(PoolObject))]
public class EffectObject : MonoBehaviour
{

    public EFFECTTAGS effTag;

    private PoolObject _poolObj;
    public PoolObject PoolObj { set { _poolObj = value; } get { return _poolObj; } }

    private void Awake()
    {
        GetComponent<PoolObject>().Reset = Reset;
        _poolObj = GetComponent<PoolObject>();
        Debug.Log(_poolObj.pooltag);
    }

    public void Init()
    {

    }

    public void EffectOff()
    {
        PoolManager.Instance.PushObject(this.gameObject);
    }

    private void Reset()
    {

    }

    public virtual void DestoryObject()
    {
        PoolManager.Instance.PushObject(this.gameObject);
    }
	
}
