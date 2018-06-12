using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_FanShapeBreath_Decorator : DecoratorTask
{
    public override bool Run()
    {

        Transform Dragon = UtilityManager.Instance.DragonTransform();
        Transform Player = UtilityManager.Instance.PlayerTransform();

        float FanShapeBreathDistance = BlackBoard.Instance.FanShapeBreathDistance;

        bool IsFanShapeBreath = UtilityManager.DistanceCalc(Dragon, Player, FanShapeBreathDistance);

        bool IsGroundAttacking = BlackBoard.Instance.IsGroundAttacking;
        bool IsFanShapeBreathAttacking = BlackBoard.Instance.IsFanShapeBreathAttacking;

        if ((IsFanShapeBreath && !IsGroundAttacking) || IsFanShapeBreathAttacking)
        {
            return ChildNode.Run();
        }

        return true;
    }


}
