using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Walk_Decorator : DecoratorTask
{

    public override bool Run()
    {
        bool IsWalk = BlackBoard.Instance.IsWalk;
        bool IsGround = BlackBoard.Instance.IsGround;
        bool IsGroundPatternAct = BlackBoard.Instance.IsGroundPatternAct;
        float CurWalkTime = BlackBoard.Instance.GetGroundTime().CurWalkTime;
        float MaxWalkTime = BlackBoard.Instance.GetGroundTime().MaxWalkTime;

        if (IsWalk && IsGround && !IsGroundPatternAct && CurWalkTime < MaxWalkTime)
        {
            Debug.Log("Walk");
            return ChildNode.Run();
        }
        return true;
    }

}
