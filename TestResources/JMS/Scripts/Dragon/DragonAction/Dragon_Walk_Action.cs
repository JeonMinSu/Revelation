using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Walk_Action : ActionTask
{

    public override bool Run()
    {

        Transform Dragon = DragonManager.Instance.transform;
        Transform Player = DragonManager.Instance.Player;

        Vector3 forward = (Player.position - Dragon.position).normalized;

        float WalkSpeed = DragonManager.Stat.WalkSpeed;
        float TurnSpeed = DragonManager.Stat.TurnSpeed;

        float CurWalkTime = BlackBoard.Instance.GetGroundTime().CurWalkTime;
        float MaxWalkTime = BlackBoard.Instance.GetGroundTime().MaxWalkTime;

        DragonManager.Instance.SwicthAnimation("Walk");


        Dragon.rotation =
            Quaternion.Slerp(
                Dragon.rotation,
                Quaternion.LookRotation(forward),
                 CurWalkTime / MaxWalkTime * 0.1f);

        Dragon.position =
            Vector3.MoveTowards(
                Dragon.position,
                Player.position,
                WalkSpeed * Time.deltaTime);

        BlackBoard.Instance.GetGroundTime().CurWalkTime += Time.deltaTime;

        return BlackBoard.Instance.DistanceCalc(Dragon, Player, 30.0f);
    }

}
