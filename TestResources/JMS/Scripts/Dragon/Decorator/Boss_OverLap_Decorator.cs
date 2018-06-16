using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_OverLap_Decorator : DecoratorTask
{

    public override bool Run()
    {
        bool IsOverLap = BlackBoard.Instance.IsOverLapAttack;

        bool IsGroundAttacking = BlackBoard.Instance.IsGroundAttacking;
        bool IsOverLapAttacking = BlackBoard.Instance.IsOverLapAttacking;

        bool IsRushAttacking = BlackBoard.Instance.IsRushAttacking;
        bool IsSecondAttack = BlackBoard.Instance.IsSecondAttack;

        if ((IsOverLap && !IsGroundAttacking && !IsRushAttacking) || 
            ((IsSecondAttack && !IsRushAttacking) || IsOverLapAttacking))
        {
            return ChildNode.Run();
        }

        return true;
    }

}
