using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_NearHowling_Decorator : DecoratorTask
{
    public override bool Run()
    {
        bool IsNearHowlingAttacking = BlackBoard.Instance.IsNearHowlingAttacking;

        bool IsNearHowlingAttack = true;

        if (IsNearHowlingAttacking)
        {
            return ChildNode.Run();
        }

        return false;
    }

}
