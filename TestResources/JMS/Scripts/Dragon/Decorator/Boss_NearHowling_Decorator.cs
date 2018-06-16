using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_NearHowling_Decorator : DecoratorTask
{
    public override bool Run()
    {
        bool IsNearHowlingAttacking = BlackBoard.Instance.IsNearHowlingAttacking;

        if (false)
        {
            return ChildNode.Run();
        }

        return true;
    }

}
