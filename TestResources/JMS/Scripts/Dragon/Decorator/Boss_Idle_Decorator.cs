using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Idle_Decorator : DecoratorTask
{
    public override bool Run()
    {
        float CurTime = BlackBoard.Instance.GetGroundTime().CurIdleTime;
        float MaxTime = BlackBoard.Instance.GetGroundTime().MaxIdleTime;

        bool IsIdle = BlackBoard.Instance.IsIdle;

        if (CurTime < MaxTime)
        {
            Debug.Log("Idle");
            return ChildNode.Run();
        }
        return false;
    }

}
