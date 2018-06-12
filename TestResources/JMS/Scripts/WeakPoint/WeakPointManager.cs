using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public struct WeakPointData
{
    public Transform _parentTransform;
    [HideInInspector]public bool _isWeakPointCreate;
}

public class WeakPointManager : Singleton<WeakPointManager>
{
    [SerializeField]
    private WeakPoint _weakPoint;

    [SerializeField]
    private List<WeakPointData> _weakPointDatas = new List<WeakPointData>();

    private int _currentParnetIndex = 0;

    //https://code.i-harness.com/ko/q/241fc40
    private void Awake()
    {
        var validValues = Enumerable.Range(0, _weakPointDatas.Count).Except(new int[] { 1 }).ToArray();

        ParticleManager.Instance.PoolParticleEffectOn(_weakPoint.gameObject);
    } 

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
