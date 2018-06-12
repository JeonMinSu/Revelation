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

        if ((IsOverLap && !IsGroundAttacking) && 
            ((IsSecondAttack && !IsRushAttacking) || IsOverLapAttacking))
        {
            Debug.Log("OverLap_Attack_Decorator");
            return ChildNode.Run();
        }

        return true;
    }

}
