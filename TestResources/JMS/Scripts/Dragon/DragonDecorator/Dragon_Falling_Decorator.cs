using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Falling_Decorator : DecoratorTask
{

    public override bool Run()
    {
        bool IsHovering = BlackBoard.Instance.IsHovering;
        bool IsFlying = BlackBoard.Instance.IsFlying;

        if (IsHovering || IsFlying)
        {
            return ChildNode.Run();
        }

        return false;
    }

}
