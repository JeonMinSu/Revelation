using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 작성일 : 2018-06-10
/// 작성자 : 전민수
/// 작성내용 : 파티클들을 관리해주는 매니져
/// </summary>

public class ParticleManager : Singleton<ParticleManager>
{
    //내부적으로 가지고 있는 파티클들 데이터
    [SerializeField]
    private List<PoolObject> _particlesDatas;

    /// <summary>
    /// 파티클오브젝트들, 사용하는 오브젝트의 태그값이 키
    /// </summary>
    
    private Dictionary<string, PoolObject> _particles = new Dictionary<string, PoolObject>();
    public Dictionary<string, PoolObject> particles { get { return _particles; } }

    //private void Awake()
    //{
    //    //내부적으로 가지고 있는 파티클들 초기화
    //    InnerPacticleEffectInit();
    //}

    ///// <summary>
    ///// 내부적으로 가지고 있는 파티클이펙트 초기화
    ///// </summary> 
    //private void InnerPacticleEffectInit()
    //{
    //    foreach (PoolObject obj in _particlesDatas)
    //    {
    //        if (obj == null)
    //        {
    //            Debug.LogWarning("particles Object Null");
    //            continue;
    //        }
    //        if (!_particles.ContainsKey(obj.pooltag))
    //        {
    //            _particles.Add(obj.pooltag, obj);
    //            PoolManager.Instance.PushObject(obj.gameObject);
    //            obj.gameObject.SetActive(false);
    //        }
    //        else
    //        {
    //            _particles[obj.pooltag] = obj;
    //            PoolManager.Instance.PushObject(obj.gameObject);
    //            obj.gameObject.SetActive(false);
    //        }
    //    }
    //}

    ///// <summary>
    ///// 내부적으로 가지고 있는 파티클들을 켜주는 함수
    ///// </summary>
    ///// <param name="useTag">파티클을 사용할 오브젝트 태그</param>
    ///// <param name="obj">파티클 오브젝트</param>
    ///// <param name="thisPos">현재 트랜스폼</param>
    //public void InnerPacticleEffectOn(PoolObject obj)
    //{
    //    foreach (KeyValuePair<string, PoolObject> particle in _particles)
    //    {
    //        if (particle.Value.pooltag == obj.pooltag)
    //        {
    //            obj.gameObject.SetActive(true);
    //            Debug.LogWarning("Found the particle in the object.");
    //            return;
    //        }
    //    }
    //    Debug.LogWarning("Not found any particles in the object.");
    //    return;
    //}

    ///// <summary>
    ///// 내부적으로 가지고 있는 파티클들을 켜주는 함수
    ///// </summary>
    ///// <param name="useTag">파티클을 사용할 오브젝트 태그</param>
    ///// <param name="obj">파티클 오브젝트</param>
    ///// <param name="Pos">사용할 위치</param>
    //public void InnerPacticleEffectOn(PoolObject obj, Vector3 pos)
    //{
    //    foreach (KeyValuePair<string, PoolObject>particle in _particles)
    //    {
    //        if (particle.Key == obj.pooltag)
    //        {
    //            obj.transform.position = pos;
    //            obj.gameObject.SetActive(true);
    //            Debug.LogWarning("Found the particle in the object.");
    //            return;
    //        }

    //    }
    //    Debug.LogWarning("Not found any particles in the object");
    //    return;
    //}

    ///// <summary>
    ///// 내부적으로 가지고 있는 파티클들을 껴주는 함수
    ///// </summary>
    ///// <param name="obj">파티클 오브젝트</param>
    //public void InnerPacticleEffectOff(PoolObject obj)
    //{
    //    foreach (KeyValuePair<string, PoolObject> particle in _particles)
    //    {
    //        if (obj.pooltag == particle.Value.pooltag)
    //        {
    //            Debug.LogWarning("Found the particle in the object.");
    //            obj.gameObject.SetActive(false);
    //            return;
    //        }
    //    }
    //    Debug.LogWarning("Not found any particles in the object");
    //}

    /// <summary>
    /// 오브젝트 풀링으로 관리해주는 파티클들을 켜주는 함수
    /// </summary>
    /// <param name="obj">파티클 오브젝트</param>
    public void PoolPacticleEffectOn(PoolObject obj)
    {
        GameObject Pacticle;
        PoolManager.Instance.PopObject(obj.pooltag, out Pacticle);

        if (Pacticle !=null)
        {
            Pacticle.GetComponent<PoolObject>().Init();
            Debug.LogWarning("Found the particle in the object.");
        }

    }

    /// <summary>
    /// 오브젝트 풀링으로 관리해주는 파티클들을 켜주는 함수
    /// </summary>
    /// <param name="obj">파티클 오브젝트</param>
    /// <param name="createPos">파티클 생성되는 위치</param>
    public void PoolPacticleEffectOn(PoolObject obj, Transform createPos)
    {
        GameObject Pacticle;
        PoolManager.Instance.PopObject(obj.pooltag, out Pacticle);

        if (Pacticle != null)
        {
            Pacticle.transform.position = createPos.position;
            Pacticle.transform.rotation = createPos.rotation;
            Pacticle.GetComponent<PoolObject>().Init();
            Debug.Log("Found the particle in the object.");
        }

    }

    /// <summary>
    /// 오브젝트 풀링으로 관리해주는 파티클들을 켜주는 함수
    /// </summary>
    /// <param name="obj">파티클 오브젝트</param>
    /// <param name="createPos">생성되는 위치</param>
    /// <param name="createDir">생성되는 방향</param>
    public void PoolPacticleEffectOn(PoolObject obj, Vector3 createPos, Vector3 createDir)
    {
        GameObject Pacticle;
        PoolManager.Instance.PopObject(obj.pooltag, out Pacticle);

        if (Pacticle != null)
        {
            Pacticle.transform.position = createPos;
            Pacticle.transform.rotation = Quaternion.LookRotation(createDir, Vector3.up);
            Pacticle.GetComponent<PoolObject>().Init();
            Debug.Log("Found the particle in the object.");
        }

    }

    /// <summary>
    /// 오브젝트 풀링으로 관리해주는 파티클들을 껴주는 함수
    /// </summary>
    /// <param name="obj">파티클 오브젝트</param>
    public void PoolPacticleEffectOff(PoolObject obj)
    {
        PoolManager.Instance.PushObject(obj.gameObject);
    }


}
