using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_OverLap_Decorator : DecoratorTask
{
    public override bool Run()
    {
        Transform Dragon = DragonManager.Instance.transform;
        Transform Player = DragonManager.Instance.Player;

        float OverLapDistance = BlackBoard.Instance.OverLapDistance;

        bool IsOverLapPattern = BlackBoard.Instance.IsOverLapPattern;
        bool IsRushPattern = BlackBoard.Instance.IsRushPattern;
        bool IsIceBringUpPattern = BlackBoard.Instance.IsIceBringUpPattern;
        bool IsBulletBreath = BlackBoard.Instance.IsBulletBreath;

        if ((BlackBoard.Instance.DistanceCalc(Dragon, Player, OverLapDistance)
            && !IsRushPattern && !IsIceBringUpPattern && !IsBulletBreath)
            || IsOverLapPattern)
        {
            Debug.Log("OverLap_Decorator");
            return ChildNode.Run();
        }
        return true;
    }

}
