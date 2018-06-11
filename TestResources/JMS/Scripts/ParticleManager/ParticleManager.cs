using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 작성일 : 2018-06-10
/// 작성자 : 전민수
/// 작성내용 : 파티클들을 관리해주는 매니져
/// 
/// 수정일 : 2018-06-11
/// 수정자 : 전민수
/// 수정내용 : 내부적으로 가지고 있는 파티클 및 외부적으로 가지고 있는 파티클까지 관리 가능
/// </summary>

public class ParticleManager : Singleton<ParticleManager>
{
    [SerializeField]
    private List<PoolObject> _particlesDatas;

    /// <summary>
    /// 파티클오브젝트들 사용하는 PoolObject의 태그값이 키
    /// </summary>
    private Dictionary<string, PoolObject> _particles = new Dictionary<string, PoolObject>();

    private void Awake()
    {
        //파티클들 초기화
        PacticleEffectInit();
    }

    /// <summary>
    /// 파티클이펙트 초기화
    /// </summary> 
    private void PacticleEffectInit()
    {
        foreach (PoolObject obj in _particlesDatas)
        {
            if (obj == null)
            {
                Debug.LogWarning("particles Object Null");
                continue;
            }
            if (!_particles.ContainsKey(obj.pooltag))
                _particles.Add(obj.pooltag, obj);
            else
                _particles[obj.pooltag] = obj;

            PoolManager.Instance.PushObject(obj.gameObject);
        }
    }

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
    /// 오브젝트 풀링으로 관리해주는 파티클을 켜주는 함수
    /// </summary>
    /// <param name="ParticleTag">파티클 태그</param>
    public void PoolParticleEffectOn(string ParticleTag)
    {
        PoolObject Particle;
        _particles.TryGetValue(ParticleTag, out Particle);

        if (Particle != null)
        {
            PoolParticleEffectOn(Particle);
            return;
        }
        Debug.LogWarning("Not Found any Particles in the object.");
    }

    /// <summary>
    /// 오브젝트 풀링으로 관리해주는 파티클을 켜주는 함수
    /// </summary>
    /// <param name="ParticleTag">파티클 태그</param>
    /// <param name="createPos">생성될 파티클의 트랜스폼 포지션</param>
    public void PoolParticleEffectOn(string ParticleTag, Transform createPos)
    {
        PoolObject particle;
        _particles.TryGetValue(ParticleTag, out particle);

        if (particle != null)
        {
            particle.transform.position = createPos.position;
            particle.transform.rotation = createPos.rotation;
            PoolParticleEffectOn(particle);
            return;
        }
        Debug.LogWarning("Not Found any Particles in the object.");
    }

    /// <summary>
    /// 오브젝트 풀링으로 관리해주는 파티클을 켜주는 함수
    /// </summary>
    /// <param name="ParticleTag">파티클 태그</param>
    /// <param name="createPos">생성될 파티클 포지션</param>
    /// <param name="createDir">생성될 파티클 방향</param>
    public void PoolParticleEffectOn(string ParticleTag, Vector3 createPos, Vector3 createDir)
    {
        PoolObject particle;
        _particles.TryGetValue(ParticleTag, out particle);

        if (particle != null)
        {
            Quaternion rot = Quaternion.LookRotation(createDir, Vector3.up);
            particle.transform.position = createPos;
            particle.transform.rotation = rot;
            PoolParticleEffectOn(particle);
            return;
        }
        Debug.LogWarning("Not Found any Particles in the object.");
    }

    /// <summary>
    /// 오브젝트 풀링으로 관리해주는 파티클을 껴주는 함수
    /// </summary>
    /// <param name="ParticleTag">파티클 태그</param>
    public void PoolParticleEffectOff(string ParticleTag)
    {
        PoolObject particle;
        _particles.TryGetValue(ParticleTag, out particle);

        if (particle != null)
        {
            PoolManager.Instance.PushObject(particle.gameObject);
            Debug.LogWarning("Found the particle in the object.");
            return;
        }
        Debug.LogWarning("Not Found any Particles in the object.");

    }

    /// <summary>
    /// 오브젝트 풀링으로 관리해주는 파티클들을 켜주는 함수
    /// </summary>
    /// <param name="obj">파티클 오브젝트</param>
    public void PoolParticleEffectOn(PoolObject obj)
    {
        if (_particles.ContainsKey(obj.pooltag))
        {
            GameObject Particle;
            PoolManager.Instance.PopObject(obj.pooltag, out Particle);

            if (Particle != null)
            {
                Particle.GetComponent<PoolObject>().Init();
                Debug.LogWarning("Found the particle in the object.");
                return;
            }
        }
        Debug.LogWarning("Not Found any Particles in the object.");
    }

    /// <summary>
    /// 오브젝트 풀링으로 관리해주는 파티클들을 켜주는 함수
    /// </summary>
    /// <param name="obj">파티클 오브젝트</param>
    /// <param name="createPos">생성될 파티클의 트랜스폼 포지션</param>
    public void PoolParticleEffectOn(PoolObject obj, Transform createPos)
    {
        if (_particles.ContainsKey(obj.pooltag))
        {
            GameObject Particle;
            PoolManager.Instance.PopObject(obj.pooltag, out Particle);

            if (Particle != null)
            {
                Particle.transform.position = createPos.position;
                Particle.transform.rotation = createPos.rotation;
                Particle.GetComponent<PoolObject>().Init();
                Debug.Log("Found the particle in the object.");
                return;
            }
        }
        Debug.LogWarning("Not Found any Particles in the object.");

    }

    /// <summary>
    /// 오브젝트 풀링으로 관리해주는 파티클들을 켜주는 함수
    /// </summary>
    /// <param name="obj">파티클 오브젝트</param>
    /// <param name="createPos">생성될 파티클 포지션</param>
    /// <param name="createDir">생성될 파티클 방향</param>
    public void PoolParticleEffectOn(PoolObject obj, Vector3 createPos, Vector3 createDir)
    {

        if (_particles.ContainsKey(obj.pooltag))
        {
            GameObject Particle;
            PoolManager.Instance.PopObject(obj.pooltag, out Particle);

            if (Particle != null)
            {
                Particle.transform.position = createPos;
                Particle.transform.rotation = Quaternion.LookRotation(createDir, Vector3.up);
                Particle.GetComponent<PoolObject>().Init();
                Debug.Log("Found the particle in the object.");
                return;
            }
        }
        Debug.LogWarning("Not Found any Particles in the object.");
    }

    /// <summary>
    /// 오브젝트 풀링으로 관리해주는 파티클들을 껴주는 함수
    /// </summary>
    /// <param name="obj">파티클 오브젝트</param>
    public void PoolParticleEffectOff(PoolObject obj)
    {
        if (_particles.ContainsKey(obj.pooltag))
        {
            PoolManager.Instance.PushObject(_particles[obj.pooltag].gameObject);
            Debug.LogWarning("Found the particle in the object.");
            return;
        }
        Debug.LogWarning("Not Found any Particles in the object.");
    }
}
