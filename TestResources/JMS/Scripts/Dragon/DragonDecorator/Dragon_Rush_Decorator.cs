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

        Debug.Log(RushDistance);

        if(BlackBoard.Instance.DistanceCalc(Dragon, Player, RushDistance))
        {
            Debug.Log("Rush");

            return ChildNode.Run();
        }

        return false;
    }

}
