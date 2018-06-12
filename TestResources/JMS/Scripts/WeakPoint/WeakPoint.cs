using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPoint : MonoBehaviour
{
    public delegate void DestroyFunction();
    public DestroyFunction DestroyFunc;

    private float _createTime;
    public float CreateTime { get { return _createTime; } }

    private ParticleObject _particle;

    private void Awake()
    {
        _particle = GetComponent<ParticleObject>();
        DestroyFunc = DestoryObject;
    }

    private void DestoryObject()
    {
        PoolManager.Instance.PushObject(this.gameObject);
    }


}
