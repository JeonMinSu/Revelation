using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Hovering_Decorator : DecoratorTask
{
    public override bool Run()
    {

        bool IsHovering = BlackBoard.Instance.IsHovering;
        bool FlyingAct = BlackBoard.Instance.FlyingAct;

        if (IsHovering && !FlyingAct)
        {
            return ChildNode.Run();
        }
        return true;

    }

}
