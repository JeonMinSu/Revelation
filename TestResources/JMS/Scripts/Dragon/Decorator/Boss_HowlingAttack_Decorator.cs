using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_HowlingAttack_Decorator : DecoratorTask
{

    public override bool Run()
    {

        Transform Boss = UtilityManager.Instance.DragonTransform();
        Transform Player = UtilityManager.Instance.PlayerTransform();

        float RoarDistanceLimit = BlackBoard.Instance.RoarDistance;

        bool IsRoar = UtilityManager.DistanceCalc(Boss, Player, RoarDistanceLimit);

        bool IsRoarAttacking = BlackBoard.Instance.IsRoarAttacking;
        bool IsGroundAttacking = BlackBoard.Instance.IsGroundAttacking;
        bool IsRoarAttack = BlackBoard.Instance.IsRoarAttacking;

        if ((IsRoar && !IsGroundAttacking) || IsRoarAttacking)
        {
            Debug.Log("Roar_Attack_Decorator");

            return ChildNode.Run();
        }

        return true;
    }

}
