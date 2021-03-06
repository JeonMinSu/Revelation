﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Idle_Decorator : DecoratorTask
{
    public override bool Run()
    {
        float CurTime = BlackBoard.Instance.GetGroundTime().CurIdleTime;
        float MaxTime = BlackBoard.Instance.GetGroundTime().MaxIdleTime;

        if (CurTime < MaxTime)
        {
            return ChildNode.Run();
        }

        return true;
    }

}
