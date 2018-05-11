using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Hovring_Decorator : DecoratorTask
{
    public override bool Run()
    { 

        bool IsHovering = BlackBoard.Instance.IsHovering;

        bool IsGroundPatternAct = BlackBoard.Instance.IsGroundPatternAct;
        bool IsFlyingPatternAct = BlackBoard.Instance.IsFlyingPatternAct;

        if (IsHovering && !IsGroundPatternAct && !IsFlyingPatternAct)
        {
            return ChildNode.Run();
        }
        return true;
    }

}
