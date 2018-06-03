﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimation : MonoBehaviour {

    [SerializeField]
    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    [SerializeField]
    private GameObject triggerObject;

    [SerializeField]
    private GameObject magazine;

    [SerializeField]
    private GameObject fireParticle;

    private GameObject gun;
    bool corTurn;
    bool corShake;

    Quaternion baseRot;
    Vector3 basePos;

    private void Awake()
    {
        corTurn = false;
        corShake = false;
        gun = this.gameObject;
        baseRot = transform.localRotation;
        basePos = transform.localPosition;
    }

    private void Start()
    {
        StartCoroutine(CorTriggerAxisUpdate());
    }

    public void MagazieTurn(float time, int maxBullet)
    {
        if (corTurn) return;
        StartCoroutine(CorTurnMagazine(time, maxBullet));
    }
    public void ShakeGun(float time, float upRot, float backZ)
    {
        if (corShake) return;
        StartCoroutine(CorGunShake(time, upRot, backZ));
    }
    public void FireParticle(Vector3 position)
    {
        fireParticle.transform.position = position;
        fireParticle.SetActive(true);
    }

    IEnumerator CorTurnMagazine(float playTime, int maxBulletCount)
    {
        corTurn = true;
        float moveAngle = 360.0f / (float)maxBulletCount;
        Vector3 currentAngle = magazine.transform.localEulerAngles;

        for(float t = 0.0f; t<playTime; t += Time.deltaTime)
        {
            magazine.transform.localEulerAngles = currentAngle + new Vector3(0.0f, 0.0f, moveAngle * t / playTime);
            yield return new WaitForEndOfFrame();
        }
        magazine.transform.localEulerAngles = currentAngle + new Vector3(0.0f, 0.0f, moveAngle);

        corTurn = false;

        yield return null;

    }
    IEnumerator CorGunShake(float playTime,float upRot, float backZ)
    {

        corShake = true;
        float waitTime = playTime * 0.1f;
        float upTime = playTime * 0.3f;
        float downTime = playTime * 0.4f;

        yield return new WaitForSeconds(waitTime);

        
        Quaternion changeRot = baseRot * Quaternion.Euler(-upRot, 0, 0);
        Vector3 changePos = basePos - gun.transform.localRotation * new Vector3(0,0,backZ);
        //changePos = gun.transform.worldToLocalMatrix * changePos;
        for (float t = 0.0f; t < upTime; t += Time.deltaTime)
        {

            gun.transform.localRotation = Quaternion.Lerp(baseRot, changeRot, t / upTime);
            gun.transform.localPosition = Vector3.Lerp(basePos, changePos, t / upTime);
            yield return new WaitForEndOfFrame();
        }

        for(float t = 0.0f; t < downTime; t += Time.deltaTime)
        {
            gun.transform.localRotation = Quaternion.Lerp(changeRot,baseRot, t / downTime);
            gun.transform.localPosition = Vector3.Lerp(changePos, basePos, t / downTime);
            yield return new WaitForEndOfFrame();
        }

        gun.transform.localPosition = basePos;
        gun.transform.localRotation = baseRot;
        corShake = false;
        yield return null;
    }
    IEnumerator CorTriggerAxisUpdate()
    {
        float axis;
        for(; ;)
        {
            axis = Controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x;
            triggerObject.transform.localRotation = Quaternion.Euler(axis * 40.0f, 0.0f, 0.0f);
            yield return null;
        }
    }
}
