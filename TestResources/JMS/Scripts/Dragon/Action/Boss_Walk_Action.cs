using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonController;

public class Boss_Walk_Action : ActionTask
{

    public override bool Run()
    {
        Transform Dragon = UtilityManager.Instance.DragonTransform();
        Transform Player = UtilityManager.Instance.PlayerTransform();

        Vector3 DragonPos = UtilityManager.Instance.DragonPosition();
        Vector3 PlayerPos = UtilityManager.Instance.PlayerPosition();

        DragonPos.y = 0.0f;
        PlayerPos.y = 0.0f;

        DragonAniManager.SwicthAnimation("Walk");

        Vector3 forward = (PlayerPos - DragonPos).normalized;

        float curTime = BlackBoard.Instance.GetGroundTime().CurWalkTime;
        float runTime = BlackBoard.Instance.GetGroundTime().MaxWalkTime;

        if (Vector3.Dot(Dragon.forward, forward) < 0.99f)
        {
            Dragon.rotation = Quaternion.Slerp(
                    Dragon.rotation,
                    Quaternion.LookRotation(forward),
                    curTime / runTime);
        }


        Dragon.position = Vector3.MoveTowards(
            Dragon.position,
            Player.position,
            15.0f * Time.deltaTime
            );

        float WalkDistance = BlackBoard.Instance.WalkDistance;

        BlackBoard.Instance.IsWalk =
            !UtilityManager.DistanceCalc(Dragon, Player, WalkDistance);

        BlackBoard.Instance.GetGroundTime().CurWalkTime += Time.deltaTime;

        return true;
    }


}
