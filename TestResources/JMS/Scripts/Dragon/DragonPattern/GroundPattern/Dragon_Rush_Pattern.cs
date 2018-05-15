using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Rush_Pattern : ActionTask {

    public override bool Run()
    {

        float preTime = BlackBoard.Instance.GetGroundTime().PreRushTime;
        float afterTime = BlackBoard.Instance.GetGroundTime().AfterRushTime;

        bool IsGround = BlackBoard.Instance.IsGround;
        bool IsGroundAct = BlackBoard.Instance.IsGroundPatternAct;

        if (!IsGroundAct)
           CoroutineManager.DoCoroutine(DragonRushStart(preTime, afterTime));

        return false;

    }

    IEnumerator DragonRushStart(float _preTime, float _afterTime)
    {

        float Curtime = 0.0f;
        float RunTime = BlackBoard.Instance.GetGroundTime().RushRunTime;

        float Speed = BlackBoard.Instance.RushMoveDistance / RunTime;

        Transform Dragon = DragonManager.Instance.transform;
        Vector3 PlayerPos = DragonManager.Instance.Player.position;
        Vector3 forward = (PlayerPos - Dragon.position).normalized;

        DragonManager.Instance.SwicthAnimation("Idle");

        BlackBoard.Instance.IsGroundPatternAct = true;
        BlackBoard.Instance.IsRushPattern = true;

        forward.y = 0.0f;

        while (!Quaternion.Equals(Dragon.rotation, Quaternion.LookRotation(forward)))
        {
            Dragon.rotation =
                Quaternion.RotateTowards(
                    Dragon.rotation,
                    Quaternion.LookRotation(forward),
                    180.0f * Time.deltaTime);

            yield return CoroutineManager.EndOfFrame;
        }

        yield return new WaitForSeconds(_preTime);

        while (Curtime < RunTime)
        {
            Dragon.Translate(Vector3.forward * Speed * Time.deltaTime);
            Debug.Log("Rush_Attack");
            Curtime += Time.fixedDeltaTime;

            yield return CoroutineManager.EndOfFrame;
        }

        yield return new WaitForSeconds(_afterTime);

        float EnsuingDistance = BlackBoard.Instance.EnsuingDecisionDistance;

        BlackBoard.Instance.IsEnsuingAttack =
            BlackBoard.Instance.DistanceCalc(
                DragonManager.Instance.Player,
                Dragon, EnsuingDistance);

        BlackBoard.Instance.GetGroundTime().InitTime();
        BlackBoard.Instance.IsRushPattern = false;

    }



}
