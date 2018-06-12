using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_NearBreathAttack_Decorator : DecoratorTask
{

    public override bool Run()
    {
        Transform Dragon = UtilityManager.Instance.DragonTransform();
        Transform Player = UtilityManager.Instance.PlayerTransform();

        float NearBreathDistance = BlackBoard.Instance.NearBreathDistance;

        bool IsBulletBreath = UtilityManager.DistanceCalc(Dragon, Player, NearBreathDistance);

        bool IsBulletBreathAttacking = BlackBoard.Instance.IsNearBreathAttacking;
        bool IsGroundAttacking = BlackBoard.Instance.IsGroundAttacking;

        if ((IsBulletBreath && !IsGroundAttacking) || IsBulletBreathAttacking)
        {
            return ChildNode.Run();
        }

        return true;
    }


}
