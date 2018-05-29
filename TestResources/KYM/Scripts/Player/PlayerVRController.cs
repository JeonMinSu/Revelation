using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerVRState
{
    TeleportNone,
    TeleportSelect,
    Teleporting 
}

public class PlayerVRController : MonoBehaviour
{
    [SerializeField]
    private SteamVR_TrackedObject trackedObjectLeft;
    [SerializeField]
    private SteamVR_TrackedObject trackedObjectRight;
    [SerializeField]
    TeleportPointer pointer;
    [SerializeField]
    private Transform originTransform;
    [SerializeField]
    private Transform headTransform;

    [SerializeField]
    private Gun leftHandGun;
    [SerializeField]
    private Gun rightHandGun;

    PlayerVRState playerState;

    private Vector3 lastClickAngle = Vector3.zero;
    private bool isClicking = false;
    public float HapticClickAngleStep = 10;

    SteamVR_Controller.Device LeftHand
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedObjectLeft.index);
        }
    }
    SteamVR_Controller.Device RightHand
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedObjectRight.index);
        }
    }

    private void Start()
    {
        playerState = PlayerVRState.TeleportNone;
    }

    private void Update()
    {
        Teleport();
        GunFire();
    }

    void Teleport()
    {
        if (playerState == PlayerVRState.TeleportNone && trackedObjectRight.isActiveAndEnabled)
        {
            if (RightHand.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                pointer.transform.parent = trackedObjectRight.transform;
                pointer.transform.localPosition = Vector3.zero;
                pointer.transform.localRotation = Quaternion.identity;
                pointer.transform.localScale = Vector3.one;
                pointer.enabled = true;

                playerState = PlayerVRState.TeleportSelect;

                pointer.ForceupdateCurrentAngle();
                //lastClickAngle = pointer.CurrentPointVector;
                //isClicking = pointer.CanTeleport;

            }
        }
        else if (playerState == PlayerVRState.TeleportSelect)
        {
            if (RightHand.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
            {
                if (pointer.CanTeleport)
                {
                    playerState = PlayerVRState.Teleporting;
                    StartCoroutine("CorTeleport", pointer.SelectedPoint);
                }
                else
                {
                    playerState = PlayerVRState.TeleportNone;
                }
                pointer.enabled = false;
                pointer.transform.parent = null;
                pointer.transform.position = Vector3.zero;
                pointer.transform.rotation = Quaternion.identity;
                pointer.transform.localScale = Vector3.one;
            }
            //else
            //{
            //    Vector3 offset = headTransform.position - originTransform.position;
            //    offset.y = 0;

            //    if (pointer.CurrentParabolaAngleY >= 45)
            //        lastClickAngle = pointer.CurrentPointVector;

            //    float angleClickDiff = Vector3.Angle(lastClickAngle, pointer.CurrentPointVector);
            //    if(isClicking && Mathf.Abs(angleClickDiff) > HapticClickAngleStep)
            //    {
            //        lastClickAngle = pointer.CurrentPointVector;
            //        if (pointer.CanTeleport)
            //            RightHand.TriggerHapticPulse();
            //    }

            //    if (pointer.CanTeleport && !isClicking)
            //    {
            //        isClicking = true;
            //        RightHand.TriggerHapticPulse(750);
            //        lastClickAngle = pointer.CurrentPointVector;
            //    }
            //    else if (!pointer.CanTeleport && isClicking)
            //        isClicking = false;
            //}
        }
        else //playerState == PlayerVRState.Teleporting
        {

        }
    }

    void GunFire()
    {
        float rightHandAxis = 0.0f;
        float leftHandAxis = 0.0f;

        if (trackedObjectRight.isActiveAndEnabled)
            rightHandAxis = RightHand.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x;
        if(trackedObjectLeft.isActiveAndEnabled)
            leftHandAxis = LeftHand.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x;

        if (rightHandAxis >= 1.0f)
        {
            rightHandGun.Fire();
        }
        if(leftHandAxis >= 1.0f)
        {
            leftHandGun.Fire();
        }
    }



    IEnumerator CorTeleport(Vector3 teleportPosition)
    {
        Vector3 difference = originTransform.position - headTransform.position;
        float t = 0.02f;
        Vector3 startPos = originTransform.position;
        difference.y = 0;
        teleportPosition += difference;

        for (int i = 0; i < 10; i++)
        {
            originTransform.position = Vector3.Lerp(startPos, teleportPosition, (float)i / 10);
            yield return new WaitForSeconds(t);
        }
        originTransform.position = teleportPosition;
        playerState = PlayerVRState.TeleportNone;
        yield return null;
    }

    //public static bool MoveRight() { return Input.GetKey(KeyCode.D); }
    //public static bool MoveLeft() { return Input.GetKey(KeyCode.A); }
    //public static bool MoveForward() { return Input.GetKey(KeyCode.W); }
    //public static bool MoveBackward() { return Input.GetKey(KeyCode.S); }
    //public static bool Jump() { return Input.GetKeyDown(KeyCode.Space); }
    //public static bool Attack() { return Input.GetMouseButton(0); }
    //public static bool Flash() { return Input.GetKeyDown(KeyCode.LeftShift); }
    //public static bool Slow() { return Input.GetKey(KeyCode.CapsLock); }
    //public static float TurnX() { return Input.GetAxis("Mouse Y"); }
    //public static float TurnY() { return Input.GetAxis("Mouse X"); }
}
