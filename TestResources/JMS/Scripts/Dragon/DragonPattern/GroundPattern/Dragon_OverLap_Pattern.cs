using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_OverLap_Pattern : ActionTask {

    public override bool Run()
    {
        float preTime = BlackBoard.Instance.GetGroundTime().PreOverLapTime;
        float afterTime = BlackBoard.Instance.GetGroundTime().AfterOverLapTime;

        bool IsGroundAct = BlackBoard.Instance.IsGroundPatternAct;
        
        if (!IsGroundAct)
            CoroutineManager.DoCoroutine(DragonOverLapStrat(preTime, afterTime));
        
        return false;
    } 

    IEnumerator DragonOverLapStrat(float preTime, float afterTime)
    {

        float RunTime = BlackBoard.Instance.GetGroundTime().OverLapRunTime;

        Transform Dragon = DragonManager.Instance.transform;
        Transform Player = DragonManager.Instance.Player;
        Vector3 forward = (Player.position - Dragon.position).normalized;

        DragonManager.Instance.SwicthAnimation("Idle");

        NodeManager OverLapRoute = DragonManager.DragonMovement.GetNodeManager(MOVEMENTTYPE.OverLap);
        bool IsFindNodePath = false;

        BlackBoard.Instance.IsGroundPatternAct = true;
        BlackBoard.Instance.IsOverLapPattern = true;
        
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
            IsFindNodePath = DragonManager.Instance.IsFindNode(MOVEMENTTYPE.OverLap);
            yield return CoroutineManager.EndOfFrame;
        }

        yield return new WaitForSeconds(preTime);

        DragonManager.DragonMovement.MovementReady(MOVEMENTTYPE.OverLap);

        while (!OverLapRoute.IsMoveEnd)
        {
            DragonManager.DragonMovement.Movement(MOVEMENTTYPE.OverLap);
            Debug.Log(OverLapRoute.IsMoveEnd);
            //Curtime += Time.fixedDeltaTime;
            yield return CoroutineManager.FiexdUpdate;
        }

        yield return new WaitForSeconds(afterTime);

        float EnsuingDistnace = BlackBoard.Instance.EnsuingDecisionDistance;
        BlackBoard.Instance.IsEnsuingAttack = 
            BlackBoard.Instance.DistanceCalc(Player, Dragon, EnsuingDistnace);

        BlackBoard.Instance.GetGroundTime().InitTime();

        BlackBoard.Instance.IsOverLapPattern = false;
        BlackBoard.Instance.IsGroundPatternAct = false;

    }

}
