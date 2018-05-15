using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_TakeOff_Decorator : DecoratorTask
{

    public override bool Run()
    {
        Transform Dragon = DragonManager.Instance.transform;
        Transform Player = DragonManager.Instance.Player;

        float Distance = BlackBoard.Instance.TakeOffDistance;

        bool IsTakeOff = !BlackBoard.Instance.DistanceCalc(Dragon, Player, Distance);
        bool IsTakeOffEnd = BlackBoard.Instance.IsTakeOffEnd;
        bool IsTakeOffAct = BlackBoard.Instance.IsTakeOffAct;

        bool IsGround = BlackBoard.Instance.IsGround;
        bool IsGroundPatternAct = BlackBoard.Instance.IsGroundPatternAct;
        bool IsLandingAct = BlackBoard.Instance.IsLandingAct;
        
        if ((IsTakeOff && !IsGroundPatternAct && IsGround && !IsLandingAct
            && !IsTakeOffEnd) || IsTakeOffAct)
        {
            Debug.Log("TakeOff_Decorator");
            return ChildNode.Run();
        }

        return true;
    }

}
