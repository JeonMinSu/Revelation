using System.Collections;
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

    bool corTurn;

    private void Start()
    {
        corTurn = false;
    }

    // Update is called once per frame
    void Update ()
    {
        float axis = Controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x;

        triggerObject.transform.localRotation = Quaternion.Euler(axis * 40.0f, 0.0f, 0.0f);

    }

    public void MagazieTurn(float time, int maxBullet)
    {
        StartCoroutine(CorTurnMagazine(time, maxBullet));
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

}
