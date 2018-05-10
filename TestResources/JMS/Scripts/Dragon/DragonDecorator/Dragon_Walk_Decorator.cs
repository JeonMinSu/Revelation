using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Walk_Decorator : DecoratorTask
{

    public override bool Run()
    {
        bool IsWalk = BlackBoard.Instance.IsWalk;
        float CurWalkTime = BlackBoard.Instance.GetStageTime().CurWalkTime;
        float MaxWalkTime = BlackBoard.Instance.GetStageTime().MaxWalkTime;

        if (IsWalk && CurWalkTime < MaxWalkTime)
        {
            return ChildNode.Run();
        }
        return true;
    }

}
