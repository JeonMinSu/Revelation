using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Stun_Decorator : DecoratorTask
{
    public override bool Run()
    {
        int CurWeakPointCount = BlackBoard.Instance.CurWeakPointCount;
        int MaxWeakPointCount = BlackBoard.Instance.MaxWeakPointCount;

        if (CurWeakPointCount >= MaxWeakPointCount)
        {
            return ChildNode.Run();
        }
        return true;
    }

}
