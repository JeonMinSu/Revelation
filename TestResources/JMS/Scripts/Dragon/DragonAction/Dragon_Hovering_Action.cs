using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Hovering_Action : ActionTask
{

    public override bool Run()
    {
        Transform Player = DragonManager.Instance.Player;
        Transform Dragon = DragonManager.Instance.transform;

        float MaxTime = BlackBoard.Instance.GetFlyingTime().HoveringTime;
        float CurTime = BlackBoard.Instance.GetFlyingTime().CurHoveringTime;

        float t = (CurTime / MaxTime) * 0.5f;

        //Debug.Log(t);

        DragonManager.Instance.SwicthAnimation("Hovering");

        Vector3 forward = (Player.position - Dragon.position).normalized;

        Dragon.rotation =
            Quaternion.RotateTowards(
                Dragon.rotation,
                Quaternion.LookRotation(forward, Vector3.up),
               (CurTime / MaxTime));

        Debug.Log(Equals(Dragon.rotation, Quaternion.LookRotation(forward, Vector3.up)));
        BlackBoard.Instance.GetFlyingTime().CurHoveringTime += Time.deltaTime;

        return Equals(Dragon.rotation, Quaternion.LookRotation(forward, Vector3.up));

    }
}