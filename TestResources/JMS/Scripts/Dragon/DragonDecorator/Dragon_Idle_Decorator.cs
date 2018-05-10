using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Idle_Decorator : DecoratorTask
{
    public override bool Run()
    {
        float CurTime = BlackBoard.Instance.GetStageTime().CurIdleTime;
        float MaxTime = BlackBoard.Instance.GetStageTime().IdleTime;

        if (CurTime < MaxTime)
        {
            return ChildNode.Run();
        }
        return true;
    }

}
 