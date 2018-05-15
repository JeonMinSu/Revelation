using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_BulletBreath_Decorator : DecoratorTask {

    public override bool Run()
    {
        Transform Dragon = DragonManager.Instance.transform;
        Transform Player = DragonManager.Instance.Player;

        float Distance = BlackBoard.Instance.BulletBreathDistance;

        bool IsOverLapPattern = BlackBoard.Instance.IsOverLapPattern;
        bool IsRushPattern = BlackBoard.Instance.IsRushPattern;
        bool IsIceBringUpPattern = BlackBoard.Instance.IsIceBringUpPattern;
        bool IsBulletBreath = BlackBoard.Instance.IsBulletBreath;

        if ((BlackBoard.Instance.DistanceCalc(Dragon, Player, Distance) &&
            !IsIceBringUpPattern && IsOverLapPattern && IsRushPattern) ||
            IsBulletBreath)
        {
            return ChildNode.Run();
        }

        return true;
    }

}
