using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_BulletBreathAttack_Decorator : DecoratorTask
{

    public override bool Run()
    {
        Transform Dragon = UtilityManager.Instance.DragonTransform();
        Transform Player = UtilityManager.Instance.PlayerTransform();

        float BulletBreathDistanceLimit = BlackBoard.Instance.BulletBreathDistance;

        bool IsBulletBreath = UtilityManager.DistanceCalc(Dragon, Player, BulletBreathDistanceLimit);

        bool IsBulletBreathAttacking = BlackBoard.Instance.IsBulletBreathAttacking;
        bool IsGroundAttacking = BlackBoard.Instance.IsGroundAttacking;

        if ((IsBulletBreath && !IsGroundAttacking) || IsBulletBreathAttacking)
        {
            return ChildNode.Run();
        }

        return true;
    }


}
