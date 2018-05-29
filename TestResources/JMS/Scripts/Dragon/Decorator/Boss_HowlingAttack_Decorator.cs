using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_HowlingAttack_Decorator : DecoratorTask
{

    public override bool Run()
    {

        Transform Boss = UtilityManager.Instance.DragonTransform();
        Transform Player = UtilityManager.Instance.PlayerTransform();

        float HowlingDistanceLimit = BlackBoard.Instance.HowlingDistance;

        bool IsHowling = UtilityManager.DistanceCalc(Boss, Player, HowlingDistanceLimit);

        bool IsHowlingAttacking = BlackBoard.Instance.IsRoarAttacking;
        bool IsGroundAttacking = BlackBoard.Instance.IsGroundAttacking;
        bool IsHowlingAttack = BlackBoard.Instance.IsRoarAttacking;

        if ((IsHowling && !IsGroundAttacking) || IsHowlingAttacking)
        {
            Debug.Log("Howling_Attack_Decorator");

            return ChildNode.Run();
        }

        return true;
    }

}
