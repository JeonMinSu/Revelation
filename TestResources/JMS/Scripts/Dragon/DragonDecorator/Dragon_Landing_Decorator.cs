using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Landing_Decorator : DecoratorTask
{
    public override bool Run()
    {
        float CurHP = DragonManager.Stat.HP;    //현재HP
        float LandHP = DragonManager.Stat.LandHP;    //착륙 HP

        float ChangedHP = DragonManager.Stat.ChangedHP;

        bool IsFly = BlackBoard.Instance.IsFlying;
        bool IsHovering = BlackBoard.Instance.IsHovering;

        bool IsFlyingAct = BlackBoard.Instance.FlyingAct;
        bool IsHoveringAct = BlackBoard.Instance.HoveringAct;
        
        if (ChangedHP - LandHP >= CurHP && (IsFly || IsHovering)
            && (!IsFlyingAct && !IsHoveringAct))
        {
            Debug.Log("Landing");
            BlackBoard.Instance.IsLanding = true;
            return ChildNode.Run();
        }
        return true;
    }
}
