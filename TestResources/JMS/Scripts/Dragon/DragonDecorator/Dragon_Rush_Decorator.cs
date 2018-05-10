using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Rush_Decorator : DecoratorTask
{

    public override bool Run()
    {
        Transform Dragon = DragonManager.Instance.transform;
        Transform Player = DragonManager.Instance.Player;

        bool IsStageAct = BlackBoard.Instance.IsStageAct;

        if (!BlackBoard.Instance.DistanceCalc(Dragon, Player, 30.0f) && !IsStageAct)
        {
            return ChildNode.Run();
        }
        return false;
    }

}
