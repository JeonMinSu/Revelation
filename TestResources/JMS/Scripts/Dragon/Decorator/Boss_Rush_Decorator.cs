﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Rush_Decorator : DecoratorTask
{
    public override void OnStart()
    {
        Debug.Log(this.gameObject.name + " : OnStart");
        base.OnStart();
    }

    public override bool Run()
    {
        Transform Dragon = UtilityManager.Instance.DragonTransform();
        Transform Player = UtilityManager.Instance.PlayerTransform();

        float RushDistanceLimit = BlackBoard.Instance.RushDistance;

        bool IsRush = UtilityManager.DistanceCalc(Dragon, Player, RushDistanceLimit);

        bool IsRushAttacking = BlackBoard.Instance.IsRushAttacking;
        bool IsGroundAttacking = BlackBoard.Instance.IsGroundAttacking;

        bool IsOverLapAttacking = BlackBoard.Instance.IsOverLapAttacking;
        bool IsSecondAttack = BlackBoard.Instance.IsSecondAttack;

        if ((IsRush && !IsGroundAttacking) || 
            ((IsSecondAttack && !IsOverLapAttacking) || IsRushAttacking))
        {
            if (NodeState != TASKSTATE.RUNNING)
                OnStart();

            return ChildNode.Run();
        }

        if (NodeState != TASKSTATE.FAULURE)
            OnEnd();

        return true;
    }

    public override void OnEnd()
    {
        Debug.Log(this.gameObject.name + "OnEnd");
        base.OnEnd();
    }

}
