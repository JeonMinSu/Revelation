using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Rush_Decorator : DecoratorTask {

    public override bool Run()
    {
        Transform Dragon = DragonManager.Instance.transform;
        Transform Player = DragonManager.Instance.Player.transform;

        float RushDistance = BlackBoard.Instance.RushDistance;
        bool IsGroundPatternAct = BlackBoard.Instance.IsGroundPatternAct;

        bool IsOverLapPattern = BlackBoard.Instance.IsOverLapPattern;
        bool IsRushPattern = BlackBoard.Instance.IsRushPattern;
        bool IsIceBringUpPattern = BlackBoard.Instance.IsIceBringUpPattern;
        bool IsBulletBreath = BlackBoard.Instance.IsBulletBreath;


        if ((BlackBoard.Instance.DistanceCalc(Dragon, Player, RushDistance) &&
            !IsOverLapPattern && !IsIceBringUpPattern && !IsBulletBreath) ||
            IsRushPattern)
        {
            return ChildNode.Run();
        }
        return true;
    }

}
