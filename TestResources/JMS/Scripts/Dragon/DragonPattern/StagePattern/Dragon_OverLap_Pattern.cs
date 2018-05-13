using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_OverLap_Pattern : ActionTask {

    public override bool Run()
    {
        float preTime = BlackBoard.Instance.GetGroundTime().PreOverLapTime;
        float afterTime = BlackBoard.Instance.GetGroundTime().AfterOverLapTime;

        bool IsStageAct = BlackBoard.Instance.IsGroundPatternAct;
        
        if (!IsStageAct)
        {
            CoroutineManager.DoCoroutine(OverLapCor(preTime, afterTime));
        }
        
        return false;
    } 

    IEnumerator OverLapCor(float preTime, float afterTime)
    {
        float Curtime = 0.0f;
        float RunTime = BlackBoard.Instance.GetGroundTime().OverLapRunTime;

        Transform Dragon = DragonManager.Instance.transform;
        Vector3 PlayerPos = DragonManager.Instance.Player.position;
        Vector3 forward = (PlayerPos - Dragon.position).normalized;

        DragonManager.Instance.SwicthAnimation("Idle");

        NodeManager OverLapRoute = DragonManager.DragonMovement.GetNodeManager(MOVEMENTTYPE.OverLap);
        bool IsFindNodePath = false;

        BlackBoard.Instance.IsGroundPatternAct = true;
        
        while (!Quaternion.Equals(Dragon.rotation, Quaternion.LookRotation(forward)))
        {
            Dragon.rotation =
                Quaternion.RotateTowards(
                    Dragon.rotation,
                    Quaternion.LookRotation(forward),
                    360.0f * Time.deltaTime);

            yield return CoroutineManager.EndOfFrame;
        }

        while (!IsFindNodePath)
        {
            IsFindNodePath = DragonManager.Instance.IsFindNode(MOVEMENTTYPE.OverLap, 25.0f, 25.0f);
            yield return CoroutineManager.EndOfFrame;
        }

        DragonManager.DragonMovement.MovementReady(MOVEMENTTYPE.OverLap);

        yield return new WaitForSeconds(preTime);
        while (!OverLapRoute.IsMoveEnd)
        {
            DragonManager.DragonMovement.Movement(MOVEMENTTYPE.OverLap);
            //Curtime += Time.fixedDeltaTime;
            yield return CoroutineManager.EndOfFrame;
        }

        yield return new WaitForSeconds(afterTime);
        BlackBoard.Instance.GetGroundTime().InitTime();
        BlackBoard.Instance.IsGroundPatternAct = false;

    }

}
