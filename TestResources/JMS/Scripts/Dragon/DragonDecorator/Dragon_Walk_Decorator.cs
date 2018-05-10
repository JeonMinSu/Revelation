using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Walk_Decorator : DecoratorTask
{

    public override bool Run()
    {
        float CurTime = BlackBoard.Instance.GetStageTime().CurWalkTime;
        float MaxTime = BlackBoard.Instance.GetStageTime().WalkChangeTime;

        bool IsStageAct = BlackBoard.Instance.IsStageAct;

        if (CurTime < MaxTime && !IsStageAct)
        {
            return ChildNode.Run();
        }
        return true;
    }
}

