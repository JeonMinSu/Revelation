using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Walk_Decorator : DecoratorTask
{
    public override void OnStart()
    {
        base.OnStart();
    }

    public override bool Run()
    {

        Transform Dragon = UtilityManager.Instance.DragonTransform();
        Transform Player = UtilityManager.Instance.PlayerTransform();

        float WalkDistance = BlackBoard.Instance.RushDistance;

        bool IsWalk = BlackBoard.Instance.IsWalk;
        bool IsWalkDistance = UtilityManager.DistanceCalc(Dragon, Player, WalkDistance);


        bool IsGroundAttacking = BlackBoard.Instance.IsGroundAttacking;

        float curTime = BlackBoard.Instance.GetGroundTime().CurWalkTime;
        float runTime = BlackBoard.Instance.GetGroundTime().MaxWalkTime;

        if ((curTime < runTime && IsWalk && IsWalkDistance) && !IsGroundAttacking)
        {
            ActionTask childAction = ChildNode.GetComponent<ActionTask>();

            if (childAction)
            {
                if (NodeState != TASKSTATE.RUNNING || childAction.IsEnd)
                    OnStart();
            }
            else if (NodeState != TASKSTATE.RUNNING)
                OnStart();

            return ChildNode.Run();
        }
        return false;
    }

    public override void OnEnd()
    {
        base.OnEnd();
    }

}
