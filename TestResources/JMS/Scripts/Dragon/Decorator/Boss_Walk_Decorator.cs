using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Walk_Decorator : DecoratorTask
{

    public override bool Run()
    {
        bool IsWalk = BlackBoard.Instance.IsWalk;
        bool IsGroundAttacking = BlackBoard.Instance.IsGroundAttacking;

        float curTime = BlackBoard.Instance.GetGroundTime().CurWalkTime;
        float runTime = BlackBoard.Instance.GetGroundTime().MaxWalkTime;

        if ((curTime < runTime && IsWalk) && !IsGroundAttacking)
        {
            return ChildNode.Run();
        }
        return false;
    }
}
