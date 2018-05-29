using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Ground_Decorator : DecoratorTask
{
    public override bool Run()
    {
        bool IsGround = BlackBoard.Instance.IsGround;
        bool IsFlying = BlackBoard.Instance.IsFlying;

        bool IsTakeOff = BlackBoard.Instance.IsTakeOff;
        bool IsLanding = BlackBoard.Instance.IsLanding;

        if (IsGround && !IsTakeOff && !IsLanding && !IsFlying)
        {
            return ChildNode.Run();
        }
        return false;
    }
}
