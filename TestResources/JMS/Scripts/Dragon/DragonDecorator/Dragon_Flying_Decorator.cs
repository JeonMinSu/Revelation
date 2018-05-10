using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Flying_Decorator : DecoratorTask
{

    public override bool Run()
    {
        bool IsFlying = BlackBoard.Instance.IsFlying;
        bool HoveringAct = BlackBoard.Instance.HoveringAct;

        if (IsFlying && !HoveringAct)
        {
            Debug.Log("Flying");
            return ChildNode.Run();
        }
        return true;
    }

}
