using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShakePlayer : MonoBehaviour {

    [SerializeField]
    private Transform VRCamera;
    private Vector3 cameraShakePos;
    
	// Use this for initialization
	void Start ()
    {
        cameraShakePos = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("CorShakeCamera");
        }
        this.transform.localPosition = cameraShakePos;
	}

    IEnumerator CorShakeCamera()
    {

        float _shakingPlayTime = 0.3f;
        float _shakingRadius = 1.0f;
        float _shkaingWaitTime = 0.02f;
        float _time = _shakingPlayTime;
        while (_time > 0)
        {
            Vector3 shakingPos = Random.insideUnitSphere * _shakingRadius;
            cameraShakePos = (VRCamera.up * shakingPos.y + VRCamera.right * shakingPos.x) * _time / _shakingPlayTime;
            //cameraShakePos.x = shakingPos.x * _time / _shakingPlayTime;
            //cameraShakePos.y = shakingPos.y * _time / _shakingPlayTime;
            _time -= _shkaingWaitTime;
            yield return new WaitForSeconds(_shkaingWaitTime);
        }
        cameraShakePos = Vector3.zero;
        yield return null;
    }


}
