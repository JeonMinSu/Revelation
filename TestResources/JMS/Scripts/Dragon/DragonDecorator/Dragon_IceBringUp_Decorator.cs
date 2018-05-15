using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_IceBringUp_Decorator : DecoratorTask
{

    public override bool Run()
    {

        Transform Dragon = DragonManager.Instance.transform;
        Transform Player = DragonManager.Instance.Player;

        float Distance = BlackBoard.Instance.IceBringUpDistance;

        bool IsOverLapPattern = BlackBoard.Instance.IsOverLapPattern;
        bool IsRushPattern = BlackBoard.Instance.IsRushPattern;
        bool IsIceBringUpPattern = BlackBoard.Instance.IsIceBringUpPattern;
        bool IsBulletBreath = BlackBoard.Instance.IsBulletBreath;



        if ((BlackBoard.Instance.DistanceCalc(Dragon, Player, Distance) &&
            !IsRushPattern && !IsOverLapPattern && !IsBulletBreath) || 
            IsIceBringUpPattern)
        {
            Debug.Log("IceBringUP_Decorator");

            return ChildNode.Run();
        }
        return true;
    }


}
