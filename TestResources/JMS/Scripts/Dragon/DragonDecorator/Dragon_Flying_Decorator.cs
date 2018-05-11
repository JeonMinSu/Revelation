using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Flying_Decorator : DecoratorTask
{
    public override bool Run()
    {
        bool IsFlying = BlackBoard.Instance.IsFlying;
        bool IsGroundPatternAct = BlackBoard.Instance.IsGroundPatternAct;
        bool IsHoveringPatternAct = BlackBoard.Instance.IsHoveringPatternAct;

        if (IsFlying && !IsGroundPatternAct && !IsHoveringPatternAct)
        {
            return ChildNode.Run();
        }
        return false;
    }

}