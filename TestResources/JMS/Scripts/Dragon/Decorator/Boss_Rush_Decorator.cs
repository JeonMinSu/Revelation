using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Rush_Decorator : DecoratorTask
{
    public override bool Run()
    {
        Transform Dragon = UtilityManager.Instance.DragonTransform();
        Transform Player = UtilityManager.Instance.PlayerTransform();

        float RushDistanceLimit = BlackBoard.Instance.RushDistance;

        bool IsRush = UtilityManager.DistanceCalc(Dragon, Player, RushDistanceLimit);

        bool IsRushAttacking = BlackBoard.Instance.IsRushAttacking;
        bool IsGroundAttacking = BlackBoard.Instance.IsGroundAttacking;


        bool IsOverLapAttacking = BlackBoard.Instance.IsOverLapAttacking;
        bool IsSecondAttack = BlackBoard.Instance.IsSecondAttack;

        if((IsRush && !IsGroundAttacking) || 
            ((IsRushAttacking && !IsOverLapAttacking) || IsSecondAttack))
        {
            Debug.Log("Rush_Attack_Decorator");
            return ChildNode.Run();
        }

        return true;
    }
}
