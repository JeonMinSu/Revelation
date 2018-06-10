using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct PoolObjectData
{
    [SerializeField] public GameObject poolObject;
    [SerializeField] public int initialCount;
}

public class PoolManager : Singleton<PoolManager>
{
    [SerializeField]
    private PoolObjectData[] poolObjects;
    public PoolObjectData[] PoolObjects { get { return poolObjects; } }

    Dictionary<string, List<GameObject>> poolLists;

    private void Awake()
    {
        poolLists = new Dictionary<string, List<GameObject>>();

        for(int i = 0; i< poolObjects.Length; i++)
        {
            ListCreate(poolObjects[i].poolObject, poolObjects[i].initialCount);
        }
    }

    void ListCreate(GameObject _gameObject, int count)
    {
        List<GameObject> list = new List<GameObject>();

        if(_gameObject.GetComponent<PoolObject>() != null)
        {
            poolLists.Add(_gameObject.GetComponent<PoolObject>().pooltag, list);
            for (int i = 0; i < count; i++)
            {
                GameObject obj = Instantiate(_gameObject, Vector3.zero, Quaternion.identity);
                PushObject(obj);
            }
        }
        else
        {
            Debug.LogWarning(_gameObject.name +  "PoolObject component is null");
        }
    }

    public void PushObject(GameObject _gameObject)
    {
        if(_gameObject.GetComponent<PoolObject>() != null)
        {
            string _poolTag = _gameObject.GetComponent<PoolObject>().pooltag;

            if (poolLists[_poolTag] != null)
            {
                if (_gameObject.GetComponent<PoolObject>().Reset != null)
                    _gameObject.GetComponent<PoolObject>().Reset();

                _gameObject.SetActive(false);
                poolLists[_poolTag].Add(_gameObject);
            }
            else
            {
                Debug.LogWarning("Not Found" + _poolTag + "tag");
            }
        }
        else
        {
            Debug.LogWarning(_gameObject.name + "PoolObject component is null");
        }
    }

    public void PopObject(string poolTag,  out GameObject _gameObject)
    {

        if(poolLists[poolTag] != null)
        {
            if (poolLists[poolTag].Count > 0)
            {
                _gameObject = poolLists[poolTag][0];
                _gameObject.SetActive(true);
                
                poolLists[poolTag].RemoveAt(0);

            }
            else
            {
                _gameObject = null;
                Debug.LogWarning("Not Found Instance");
            }
        }
        else
        {
            _gameObject = null;
            Debug.LogWarning("Not Found" + poolTag + " tag");
        }
    }


}



