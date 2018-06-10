using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// 작성일 : 2018 - 06 - 09
/// 작성자 : 전민수
/// 작업내용 : 이펙트관리(내부적으로 가지고 있는 이펙트와 오브젝트 풀링으로 사용하는 이펙트 관리)
/// 
/// 이펙트를 추가할 시 EFFECTTAGS라는 enum에 이펙트태크 추가
/// InnerEffect로 시작하는 함수들은 이펙트가 오브젝트 내부적으로 가지고 처리하는 이펙트
/// PoolEffect로 시작하는 함수들은 오브젝트 풀링으로 처리하는 이펙트
/// 
/// 나도 이제 모르게다아아아아아아아아 ~~~@~!@~@~!@~@~!@!~@!~@
/// </summary>

[System.Serializable]
//이펙트 오브젝트 데이터
public struct EffectObjectData
{
    public GameObject UseObject;                    //이펙트를 사용할 오브젝트
    public List<PoolObject> EF_Object;              //이펙트 오브젝트

    public EffectObjectData(GameObject useObject, List<PoolObject> ef_Object)
    {
        this.UseObject = useObject;
        this.EF_Object = ef_Object;
    }

}

public class EventManager : Singleton<EventManager>
{
    //내부적으로 가지고 있는 이펙트들의 데이터
    [SerializeField]
    private List<EffectObjectData> EF_Objects = new List<EffectObjectData>();

    //내부적으로 가지고 있는 이펙트들의 모음
    private Dictionary<string, Dictionary<EFFECTTAGS, EffectObject>> Effects = new Dictionary<string, Dictionary<EFFECTTAGS, EffectObject>>();

    //오브젝트 풀링으로 처리해야 되는 이펙트들
    //private Dictionary<EFFECTTAGS, EffectObject> PoolEffects = new Dictionary<EFFECTTAGS, EffectObject>();

    private void Awake()
    {
        //내부적으로 가지고 있는 이펙트 초기화
        InnerEffectObjectInit();
        //오브젝트 풀링으로 가지고 있는 이펙트 초기화
        PoolEffectObjecInit();
    }

    /// <summary>
    /// 내부적으로 가지고 있는 이펙트 초기화
    /// </summary>
    private void InnerEffectObjectInit()
    {

        foreach (EffectObjectData eObjData in EF_Objects)
        {
            string Key = eObjData.UseObject.tag;

            foreach (EffectObject obj in eObjData.EF_Object)
            {
                if (obj == null)
                {
                    Debug.LogWarning("Object Null");
                    continue;
                }

                if (!Effects.ContainsKey(Key))
                {
                    Dictionary<EFFECTTAGS, EffectObject> eff = new Dictionary<EFFECTTAGS, EffectObject>();

                    eff.Add(obj.effTag, obj);
                    Effects.Add(Key, eff);
                    obj.gameObject.SetActive(false);
                }
                else
                {
                    if (!Effects[Key].ContainsKey(obj.effTag))
                    {
                        Effects[Key].Add(obj.effTag, obj);
                        obj.gameObject.SetActive(false);
                    }
                }
            }
        }

    }

    /// <summary>
    /// 오브젝트 풀링으로 가지고 있는 이펙트 초기화
    /// </summary>
    private void PoolEffectObjecInit()
    {
        PoolObjectData[] poolDatas = PoolManager.Instance.PoolObjects;

        foreach (PoolObjectData poolData in poolDatas)
        {
            EffectObject poolEff = poolData.poolObject.GetComponent<EffectObject>();

            if (poolEff != null)
            {
                poolEff.PoolObj = poolData.poolObject.GetComponent<PoolObject>();
                PoolEffects.Add(poolEff.effTag, poolEff);
            }
        }

    }

    /// <summary>
    /// 오브젝트의 이펙트들을 가져오는 함수
    /// </summary>
    /// <param name="Key">오브젝트의 Tag 값</param>
    /// <returns></returns>
    private Dictionary<EFFECTTAGS, EffectObject> GetEffectObejct(string Key)
    {
        Dictionary<EFFECTTAGS, EffectObject> effObjs;

        if (Effects.ContainsKey(Key))
        {
            effObjs = Effects[Key];
        }
        else
        {
            effObjs = new Dictionary<EFFECTTAGS, EffectObject>();
            Effects.Add(Key, effObjs);
        }
        return effObjs;
    }

    /// <summary>
    /// 오브젝트 풀링으로 등록되어 있는 이펙트를 켜는 함수?
    /// </summary>
    /// <param name="useObj">사용할 오브젝트</param>
    /// <param name="effTag"> 이펙트 태그</param>
    /// <param name="effect">이펙트 오브젝트를 담을 변수</param>
    public void PoolObjectEffectOn(Transform useObj, EFFECTTAGS effTag, out GameObject effect)
    {
        GameObject eff;

        if (PoolEffects.ContainsKey(effTag))
        {
            string poolTag = PoolEffects[effTag].PoolObj.pooltag;

            PoolManager.Instance.PopObject(poolTag, out eff);

            if (eff != null)
            {
                effect = eff;

                effect.transform.position = useObj.position;
                effect.transform.rotation = useObj.rotation;
                effect.GetComponent<EffectObject>().Init();
                return;
            }
        }

        effect = null;
        return;


        /*
        string useKey = useObj.tag;

        Dictionary<EFFECTTAGS, EffectObject> effs = GetEffectObejct(useKey);

        if (effs.Count <= 0)
        {
            effObj = null;
            Debug.LogWarning("not effect object");
            return;
        }

        GameObject effect;

        foreach (KeyValuePair<EFFECTTAGS, EffectObject> obj in effs)
        {
            if (obj.Value.effTag == effTag)
            {
                Debug.Log(effs[effTag].PoolObj);

                PoolManager.Instance.PopObject(obj.Value.PoolObj.pooltag, out effect);

                if (effect != null)
                {
                    effect.transform.position = useObj.position;
                    effect.transform.rotation = useObj.rotation;
                }

                effObj = effect;
                return;
            }
        }
        effObj = null;

        return;
        */
    }

    /// <summary>
    /// 오브젝트 풀링으로 등록되어 있는 이펙트를 켜는 함수?
    /// </summary>
    /// <param name="pos">이펙트 위치</param>
    /// <param name="dir"> 이펙트 방향</param>
    /// <param name="effTag">이펙트 태그</param>
    /// <param name="effect">이펙트 오브젝트를 담을 변수</param>
    public void PoolObjectEffectOn(Vector3 pos, Vector3 dir, EFFECTTAGS effTag, out GameObject effect)
    {

        GameObject eff;

        if (PoolEffects.ContainsKey(effTag))
        {
            string poolTag = PoolEffects[effTag].PoolObj.pooltag;

            PoolManager.Instance.PopObject(poolTag, out eff);

            if (eff != null)
            {
                effect = eff;
                Quaternion rot = Quaternion.LookRotation(dir, Vector3.up);

                effect.transform.position = pos;
                effect.transform.rotation = rot;
                effect.GetComponent<EffectObject>().Init();
                return;
            }
        }

        effect = null;
        return;


        /*
        string useKey = useObj.tag;

        Dictionary<EFFECTTAGS, EffectObject> effs = GetEffectObejct(useKey);

        if (effs.Count <= 0)
        {
            effObj = null;
            Debug.LogWarning("not effect object");
            return;
        }

        GameObject effect;

        foreach (KeyValuePair<EFFECTTAGS, EffectObject> obj in effs)
        {
            if (obj.Value.effTag == effTag)
            {
                PoolManager.Instance.PopObject(obj.Value.PoolObj.pooltag, out effect);
                if (effect != null)
                {
                    Quaternion rot = Quaternion.LookRotation(dir, Vector3.up);

                    effect.transform.position = pos;
                    effect.transform.rotation = rot;
                }
                effObj = effect;
                return;
            }
        }
        effObj = null;
        */
    }

    /// <summary>
    /// 오브젝트 풀링으로 등록되어 있는 이펙트를 끄는 함수
    /// </summary>
    /// <param name="effObj">이펙트를 껴야될 오브젝트</param>
    public void PoolObjectEffectOff(GameObject effObj)
    {
        PoolManager.Instance.PushObject(effObj);
    }

    /// <summary>
    /// 내부적으로 가지고 있는 이펙트를 켜는 함수
    /// </summary>
    /// <param name="useObj">사용하는 오브젝트</param>
    /// <param name="effTag">이펙트 태그</param>
    /// <param name="effObj">이펙트 오브젝트를 담을 변수</param>
    public void InnerEffectObjectOn(Transform useObj, EFFECTTAGS effTag, out GameObject effObj)
    {
        string useKey = useObj.tag;

        Dictionary<EFFECTTAGS, EffectObject> effs = GetEffectObejct(useKey);

        if (effs.Keys.Count <= 0)
        {
            Debug.LogWarning("No Use Effect Object");
            effObj = null;
            return;
        }

        foreach (KeyValuePair<EFFECTTAGS, EffectObject> obj in effs)
        {
            if (obj.Value.effTag == effTag)
            {
                effObj = Effects[useKey][effTag].gameObject;
                effObj.SetActive(true);
                return;
            }
        }

        effObj = null;
        return;
    }

    /// <summary>
    /// 내부적으로 가지고 있는 이펙트를 끄는 함수
    /// </summary>
    /// <param name="useObj">사용하는 오브젝트</param>
    /// <param name="effect">이펙트 오브젝트</param>
    public void InnerEffectObjectOff(Transform useObj, GameObject effect)
    {
        string useKey = useObj.tag;

        Dictionary<EFFECTTAGS, EffectObject> effs = GetEffectObejct(useKey);

        if (effs.Keys.Count <= 0)
        {
            Debug.Log("No Use Effects Object");
            return;
        }

        if (effect.GetComponent<EffectObject>() != null)
        {
            effect.SetActive(false);
        }
    }

    /*
    public void DragonHowlingEffectOn(Transform useObj, Vector3 pos, Vector3 dir)
    {

        string useKey = useObj.tag;
        Dictionary<string, PoolObject> effObjs = GetEffectObejct(useKey);

        if (effObjs.Keys.Count <= 0)
        {
            Debug.LogWarning("No Use Effect Object");
            return;
        }


        EffectObjectData EffData = new EffectObjectData
        {
            UseObject = useObj.gameObject,
            EF_Object = new List<PoolObject>(effObjs.Values)
        };

        foreach (PoolObject obj in EffData.EF_Object)
        {

            if (obj.pooltag == "Howling")
            {
                GameObject HowalingEff;
                PoolManager.Instance.PopObject(obj.pooltag, out HowalingEff);

                if (HowalingEff != null)
                {
                    Quaternion rot = Quaternion.LookRotation(dir, Vector3.up);

                    HowalingEff.transform.parent = useObj;

                    HowalingEff.transform.position = pos;
                    HowalingEff.transform.rotation = rot;

                    if (HowalingEff.GetComponent<Effect>())
                        HowalingEff.GetComponent<Effect>().Init();

                }
            }
        }
    }
                                    
    public void DragonHowlingEffectOn(Transform useObj)
    {
        string useKey = useObj.tag;
        Dictionary<string, PoolObject> effObjs = GetEffectObejct(useKey);

        if (effObjs.Keys.Count <= 0)
        {
            Debug.LogWarning("No Use Effect Object");
            return;
        }


        EffectObjectData EffData = new EffectObjectData
        {
            UseObject = useObj.gameObject,
            EF_Object = new List<PoolObject>(effObjs.Values)
        };

        foreach (PoolObject obj in EffData.EF_Object)
        {
            if (obj.pooltag == "Howling")
            {
                GameObject HowalingEff;
                PoolManager.Instance.PopObject(obj.pooltag, out HowalingEff);

                if (HowalingEff != null)
                {
                    Effect EffComponent = HowalingEff.GetComponent<Effect>();
                    if (EffComponent)
                    {
                        HowalingEff.transform.parent = useObj;

                        HowalingEff.transform.rotation = Quaternion.LookRotation(useObj.forward, Vector3.up);
                        HowalingEff.transform.position = EffComponent.OffSet;
                    }
                }


            }
        }

    }

    public void DragonHowlingEffectOff(Transform useObj)
    {
        string useKey = useObj.tag;

        Dictionary<string, PoolObject> effObjs = GetEffectObejct(useKey);

        if (effObjs.Keys.Count <= 0)
        {
            Debug.LogWarning("No Use Effect Object");
        }

        EffectObjectData EffData = new EffectObjectData
        {
            UseObject = useObj.gameObject,
            EF_Object = new List<PoolObject>(effObjs.Values)
        };

        foreach (PoolObject obj in EffData.EF_Object)
        {
            if (obj.pooltag == "Howling")
            {
                PoolManager.Instance.PushObject(obj.gameObject);
            }
        }

    }

    //private string GetEffectKey(Dictionary<string, PoolObject> EffObjs)
    //{
    //    //string EffKey = EffObjs.;

    //    return EffKey;
    //}

    /*
    public void EffectOn(Transform useObj, string objTag)
    {
        string useKey = useObj.tag;

        Dictionary<string, GameObject> EffObject = GetEffectObejct(useKey);

        if (EffObject.ContainsKey(objTag))
        {
            /*GameObject Effect =
            EffObject[objTag].SetActive(true);
            //PoolManager.Instance.PopObject(objKey, out Effect);

            //if (Effect != null)
            //{
            //    Effect.transform.parent = useObj;
            //}

            return;
        }
        else
        {
            GameObject Effect;
            PoolManager.Instance.PopObject(objTag, out Effect);

            if (Effect == null)
            {
                Debug.Log("Not Found" + objTag + "Tag");
                return;
            }

        }
        Debug.LogWarning("Object Null");
    }
    public void EffectOn(Transform useObj, string objTag, Vector3 effPos, Vector3 dir)
    {
        string useKey = useObj.tag;
        Dictionary<string, GameObject> EffObject = GetEffectObejct(useKey);

        if (EffObject.ContainsKey(objTag))
        {
            EffObject[objTag].SetActive(true);
            return;
        }
        else
        {

            Quaternion rot = Quaternion.LookRotation(dir, Vector3.up);
            GameObject Effect;
            PoolManager.Instance.PopObject(objTag, out Effect);
            if (Effect != null)
            {
                Effect.transform.position = effPos;
                Effect.transform.rotation = rot;
                Effect.GetComponent<Effect>().Init();
                return;
            }
            else
            {
                Debug.Log("Not Found" + objTag + "Tag");
                return;
            }
        }

    }

    public void EffectOff(Transform useObj, string objTag)
    {
        string useKey = useObj.tag;

        Dictionary<string, GameObject> EffObject = GetEffectObejct(useKey);

        if (EffObject.ContainsKey(objTag))
        {
            EffObject[objTag].SetActive(false);
            return;
        }
        else
        {

        }
        Debug.LogWarning("Object Null");
    }

    //public void PoolEffectOn(Transform useObj, Vector3 effPos, Vector3 dir, string objTag)
    //{
    //    string useKey = useObj.tag;

    //    Quaternion effRot = Quaternion.LookRotation(dir, Vector3.up);
    //    GameObject Effect;
    //    PoolManager.Instance.PopObject(objTag, out Effect);

    //    if (Effect != null)
    //    {
    //        Effect.transform.position = effPos;
    //        Effect.transform.rotation = effRot;
    //    }

    //}

    //public void PoolEffectOff(Transform useObj, Vector3 effPos, Vector3 dir, string objTag)
    //{
    //    string useKey = useObj.tag;

    //    Dictionary<string, GameObject> EffObject = GetEffectObejct(useKey);

    //    //Quaternion effRot = Quaternion.LookRotation(dir, Vector3.up);
    //    //GameObject Effect;

    //}
    */
}



