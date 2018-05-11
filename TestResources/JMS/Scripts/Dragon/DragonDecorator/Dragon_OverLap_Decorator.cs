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
        
        if (BlackBoard.Instance.DistanceCalc(Dragon, Player, OverLapDistance))
        {
            return ChildNode.Run();
        }
        return false;
    }

}
